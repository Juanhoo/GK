using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField]
    private float cameraMovementSpeed;

    [SerializeField]
    private float cameraMovementScale;

    [SerializeField]
    private SlidingBackground slidingBackgroundController;

    [SerializeField]
    private AnimationCurve MoveCurve;

    private Vector3 positionToInterpolate;
    private Vector3 playerForward;
    private float animationTimePosition;


    private void Awake() {
        positionToInterpolate = transform.position;
    }

    private void Update() {
        animationTimePosition += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, positionToInterpolate, cameraMovementSpeed * Time.deltaTime);
        slidingBackgroundController.SlideTexture(MoveCurve.Evaluate(animationTimePosition)/90, playerForward); 
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("Player")) {
            animationTimePosition = 0f;
            playerForward = other.transform.forward;
            positionToInterpolate = transform.position + other.transform.forward * cameraMovementScale;
        }
    }

}
