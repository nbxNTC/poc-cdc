using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public Player player;

    [Header("Animator")]
    private Animator _animator;

    [Header("Rigidbody")]
    private Rigidbody2D _myRigidbody;
    private Vector2 _movementInput = Vector2.zero;

    private void Start() {
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();

        player.LoadPlayer();
    }

    private void Update() {
        Movement();

        if (Input.GetMouseButtonDown(0)) {
            player.SavePlayer();

            // int index = 1;
            // List<GameObject> list = new List<GameObject>();
            // GameObject test;
            // do {
            //     test = GameObject.Find("Dialogue_0" + index);
            //     Debug.Log("Dialogue_0" + index);
            //     if (test != null) {
            //         list.Add(test);
            //     }
            //     index += 1;
            // } while (test != null);

            // Debug.Log(list.Count);
        }

        if (Input.GetMouseButtonDown(1)) {
            player.LoadPlayer();
        }
    }
        
    private void Movement() {
        _movementInput.x = Input.GetAxisRaw("Horizontal");
        _movementInput.y = Input.GetAxisRaw("Vertical");
        
        if (_movementInput != Vector2.zero && player.canMove) {
            _myRigidbody.MovePosition(transform.position += (Vector3)_movementInput * player.entity.speed * Time.deltaTime);

            _animator.SetFloat("moveX", _movementInput.x);  
            _animator.SetFloat("moveY", _movementInput.y);
            _animator.SetBool("moving", true);
        } else {
            _animator.SetBool("moving", false);
        }
    }
}