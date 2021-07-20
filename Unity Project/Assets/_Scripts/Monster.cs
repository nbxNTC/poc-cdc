using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Controller")]
    public Entity entity;

    [Header("Exp")]
    public int expFeed = 100;

    [Header("Battle System")]
    public BattleSystem battleSystem;

    void Start () {
        entity.currentHealth = entity.maxHealth;

        entity.damage = 30;
    }

    public bool TakeDamage(int damage) {
        entity.currentHealth -= damage;

        if (entity.currentHealth <= 0) return true;
        else return false;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();

            battleSystem.StartBattle(player, this);
        }
    }
}