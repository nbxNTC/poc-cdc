using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Properties
    [SerializeField]
    private float _speed = 30.0f;     

    // Player Animations
    private Animator _animator;

    // Rigidbody     
    private Rigidbody2D _myRigidbody;   
    private Vector3 _movementInput;         
        
    private void Start() {
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();                  
    }

    private void Update() {
        Movement();                   
    }

    // Player Function
    private void Movement() {   
        _movementInput = Vector3.zero;   

        _movementInput.x = Input.GetAxisRaw("Horizontal");
        _movementInput.y = Input.GetAxisRaw("Vertical");
        
        if (_movementInput != Vector3.zero) {
            _myRigidbody.MovePosition(
                transform.position + _movementInput * _speed * Time.deltaTime
            );
            
            _animator.SetFloat("moveX", _movementInput.x);  
            _animator.SetFloat("moveY", _movementInput.y);
            _animator.SetBool("moving", true);
        } else {
            _animator.SetBool("moving", false);
        }
    }    
    
}