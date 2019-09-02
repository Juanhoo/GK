using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : EnemyController
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Animator enemyAnimator;

    private int destPoint = 0;
    private int index = 0;

    private float distance;

    private void OnEnable() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void RotateTowardsPoint(Vector3 targetPos, float rotationSpeed)
    {
        Vector3 dir = targetPos - transform.position;
        dir.y = 0;

        var quaternionToRotate = Quaternion.FromToRotation(transform.right, dir) * transform.rotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, quaternionToRotate, rotationSpeed);
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance > 6f) {
            RotateTowardsPoint(points[index].position, 4f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, points[index].position, enemyData.objectData.GetSpeed() * Time.deltaTime);
            if(Vector3.Distance(transform.position, points[index].position) < 1f) { 
                index++;
                index %= 3;
            }
        }
        else {
            if(distance > 2f) {
                RotateTowardsPoint(target.position, 10f * Time.deltaTime);
                Vector3 positionToMove = target.position;
                positionToMove.y = transform.position.y;;
                transform.position = Vector3.MoveTowards(transform.position, positionToMove, enemyData.objectData.GetSpeed() * Time.deltaTime);
            }
            else {
                enemyAnimator.SetTrigger("isAttacking");
            }    
        }

    }

}
