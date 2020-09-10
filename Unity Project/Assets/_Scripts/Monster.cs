using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Controller")]
    public Entity entity;

    [Header("Exp")]
    public int expFeed = 100;

    void Start () {
        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;

        entity.damage = 10;
    }

    public bool TakeDamage(int damage) {
        entity.currentHealth -= damage;

        if (entity.currentHealth <= 0) return true;
        else return false;
    }
}