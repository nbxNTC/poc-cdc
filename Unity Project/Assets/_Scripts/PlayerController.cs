using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    // Player Properties
    public Player player;    

    // Player Animations
    private Animator _animator;

    // Rigidbody     
    private Rigidbody2D _myRigidbody;   
    private Vector2 _movementInput = Vector2.zero;
        
    private void Start() {
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>(); 
    }

    private void Update() {
        Movement();    
    }

    // Player Function
    private void Movement() {
        _movementInput.x = Input.GetAxisRaw("Horizontal");
        _movementInput.y = Input.GetAxisRaw("Vertical");
        
        if (_movementInput != Vector2.zero) {
            _myRigidbody.MovePosition(
                _myRigidbody.position + _movementInput * player.entity.speed * Time.fixedDeltaTime
            );
            
            _animator.SetFloat("moveX", _movementInput.x);  
            _animator.SetFloat("moveY", _movementInput.y);
            _animator.SetBool("moving", true);
        } else {
            _animator.SetBool("moving", false);
        }
    }
}