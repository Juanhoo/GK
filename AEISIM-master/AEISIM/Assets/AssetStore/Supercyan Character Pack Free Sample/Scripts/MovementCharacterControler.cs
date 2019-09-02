using UnityEngine;
using System.Collections.Generic;

public class MovementCharacterControler : MonoBehaviour {

    private enum ControlMode
    {
        Tank,
        Direct
    }

    [SerializeField] 
    private float moveSpeed = 2;

    [SerializeField] 
    private float turnSpeed = 200;

    [SerializeField] 
    private float jumpForce = 4;

    [SerializeField] 
    private Animator animator;

    [SerializeField] 
    private Rigidbody myRigidbody;


    [SerializeField] 
    private ControlMode controlMode = ControlMode.Direct;

    private float currentY = 0;
    private float currentH = 0;

    private readonly float interpolationConstant = 10;
    private readonly float walkScaleConstant = 0.33f;
    private readonly float backwardsWalkScaleConstant = 0.16f;
    private readonly float backwardRunScaleConstant = 0.66f;

    private bool wasGrounded;
    private Vector3 currentDirection = Vector3.zero;

    private float jumpTimeStamp = 0;
    private float minJumpInterval = 0.25f;

    private bool isGrounded;
    
    private List<Collider> collisionList = new List<Collider>();

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for(int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!collisionList.Contains(collision.collider)) {
                    collisionList.Add(collision.collider);
                }
                isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if(validSurfaceNormal)
        {
            isGrounded = true;
            if (!collisionList.Contains(collision.collider))
            {
                collisionList.Add(collision.collider);
            }
        } else
        {
            if (collisionList.Contains(collision.collider))
            {
                collisionList.Remove(collision.collider);
            }
            if (collisionList.Count == 0) { isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collisionList.Contains(collision.collider))
        {
            collisionList.Remove(collision.collider);
        }
        if (collisionList.Count == 0) { isGrounded = false; }
    }

	void Update () {
        animator.SetBool("Grounded", isGrounded);

        switch(controlMode)
        {
            case ControlMode.Direct:
                DirectUpdate();
                break;

            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }

        wasGrounded = isGrounded;
    }

    private void TankUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool walk = Input.GetKey(KeyCode.LeftShift);

        if (v < 0) {
            if (walk) { v *= backwardsWalkScaleConstant; }
            else { v *= backwardRunScaleConstant; }
        } else if(walk)
        {
            v *= walkScaleConstant;
        }

        currentY = Mathf.Lerp(currentY, v, Time.deltaTime * interpolationConstant);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * interpolationConstant);

        transform.position += transform.forward * currentY * moveSpeed * Time.deltaTime;
        transform.Rotate(0, currentH * turnSpeed * Time.deltaTime, 0);

        animator.SetFloat("MoveSpeed", currentY);

        JumpingAndLanding();
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= walkScaleConstant;
            h *= walkScaleConstant;
        }

        currentY = Mathf.Lerp(currentY, v, Time.deltaTime * interpolationConstant);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * interpolationConstant);

        Vector3 direction = camera.forward * currentY + camera.right * currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if(direction != Vector3.zero)
        {
            currentDirection = Vector3.Slerp(currentDirection, direction, Time.deltaTime * interpolationConstant);

            transform.rotation = Quaternion.LookRotation(currentDirection);
            transform.position += currentDirection * moveSpeed * Time.deltaTime;

            animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - jumpTimeStamp) >= minJumpInterval;

        if (jumpCooldownOver && isGrounded && Input.GetKey(KeyCode.Space))
        {
            jumpTimeStamp = Time.time;
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (!wasGrounded && isGrounded)
        {
            animator.SetTrigger("Land");
        }

        if (!isGrounded && wasGrounded)
        {
            animator.SetTrigger("Jump");
        }
    }
}
