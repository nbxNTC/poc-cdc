using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Properties
    [SerializeField]
    private float _horizontalSpeed = 5.0f;
    [SerializeField]
    private float _verticalSpeed = 5.0f;        
        
    private void Start() {
        transform.position = new Vector3(-6.68f, -3.56f, 0);
    }

    private void Update() {
        Movement();                   
    }

    // Player Function
    private void Movement() {
        
        float h = _horizontalSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        // float v = _verticalSpeed * Input.GetAxis("Vertical") * Time.deltaTime;        

        transform.Translate(h, 0, 0);

        // // Screen Vertical Limit
        // if (transform.position.y > 0) {
        //     transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // } else if (transform.position.y < -4.2f) {
        //     transform.position = new Vector3(transform.position.x, -4.2f, transform.position.z);
        // }
        // Screen Horizontal Limit
        if (transform.position.x > 9.4f) {
            transform.position = new Vector3(-9.4f, transform.position.y, transform.position.z);
        } else if (transform.position.x < -9.4f) {
            transform.position = new Vector3(9.4f, transform.position.y, transform.position.z);
        }
    }    
    
}