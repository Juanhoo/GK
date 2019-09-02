using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    public Vector3 GetRandomPositionInArea() {
        Vector3 origin = transform.position;
        Vector3 range = new Vector3(transform.localScale.x * 3, 0, transform.localScale.z * 6);
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                        0,
                                        Random.Range(-range.z, range.z));
        Vector3 randomCoordinate = origin + randomRange;
        return randomCoordinate;
    }

    private void OnDrawGizmos()
    {   
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, new Vector3(transform.localScale.x * 3, transform.localScale.y, transform.localScale.z * 6));
    }
}
