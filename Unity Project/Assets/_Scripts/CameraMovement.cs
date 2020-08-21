using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    [SerializeField]
    private float _smoothing = 0.6f;
    [SerializeField]
    private Vector2 _maxPosition;
    [SerializeField]
    private Vector2 _minPosition;

    void Start() {
        
    }

    void LateUpdate() {
        if (transform.position != target.position) {
            Vector3 targetPosition = new Vector3(
                target.position.x,
                target.position.y,
                transform.position.z
            );

            // targetPosition.x = Mathf.Clamp(
            //     targetPosition.x,
            //     _minPosition.x,
            //     _maxPosition.x
            // );
            // targetPosition.y = Mathf.Clamp(
            //     targetPosition.y,
            //     _minPosition.y,
            //     _maxPosition.y
            // );

            transform.position = Vector3.Lerp(
                transform.position, 
                targetPosition,
                _smoothing
            );
        }
    }
}
