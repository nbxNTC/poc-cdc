using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Properties
    [SerializeField]
    private float _speed = 5.0f;     

    //Rigidbody     
    private Rigidbody2D _myRigidbody;    
        
    private void Start() {
        transform.position = new Vector2(-6.68f, -3.56f);
        
    }

    private void Update() {
        Movement();                   
    }

    // Player Function
    private void Movement() {        
        float h = _speed * Input.GetAxis("Horizontal") * Time.deltaTime;
               
        transform.Translate(h, 0, 0);       
        
        // Screen Horizontal Limit
        if (transform.position.x > 9.4f) {
            transform.position = new Vector3(-9.4f, transform.position.y, transform.position.z);
        } else if (transform.position.x < -9.4f) {
            transform.position = new Vector3(9.4f, transform.position.y, transform.position.z);
        }
    }    
    
}