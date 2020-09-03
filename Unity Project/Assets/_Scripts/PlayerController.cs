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
        Attack();
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

    private void Attack() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine() {
        if (player.entity.canAttack) {
            Monster monster = player.entity.target.GetComponent<Monster>();
            monster.entity.currentHealth -= player.entity.damage;
            monster.entity.target = this.gameObject;
            
            player.entity.canAttack = false;
            yield return new WaitForSeconds(player.entity.fireRate);
            player.entity.canAttack = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "Enemy") return;
        player.entity.canAttack = true;
        Monster monster = collision.GetComponent<Monster>();
        monster.entity.target = player.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag != "Enemy") return;
        player.entity.canAttack = false;
    }
    
}