using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    [SerializeField]
    private float smoothing = 0.6f;

    void Start() {
        
    }

    void LateUpdate() {
        if (transform.position != target.position) {
            Vector3 targetPosition = new Vector3(
                target.position.x,
                target.position.y,
                transform.position.z
            );

            transform.position = Vector3.Lerp(
                transform.position, 
                targetPosition,
                smoothing
            );
        }
    }
}
