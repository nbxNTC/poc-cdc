using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [Header("Controller")]
    public Entity entity;
    public bool canMove = true;

    [Header("Exp")]
    public int currentExp = 0;
    public int expLeft = 50;
    public GameObject levelUpFX;
    public AudioClip levelUpSound;
    
    void Start() {
        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;

        entity.resistence = 1;
        entity.damage = 50;    
        entity.speed = 3f;
    }

    public bool TakeDamage(int damage) {
        int updatedDamage = damage - entity.resistence;

        if (updatedDamage > 0) entity.currentHealth -= updatedDamage;

        if (entity.currentHealth <= 0) return true;
        else return false;
    }

    public void Heal(int health) {
        entity.currentHealth += health;

        if (entity.currentHealth > entity.maxHealth) 
            entity.currentHealth = entity.maxHealth;
    }

    public void GainExp (int amount) {
        currentExp += amount;
        if (currentExp >= expLeft) LevelUp();
    }

    public void LevelUp () {
        while (currentExp >= expLeft) {
            currentExp -= expLeft;
            expLeft += 50;
            entity.level++;

            entity.damage += 7;
            entity.resistence += 5;
        }
        entity.currentHealth = entity.maxHealth;

        entity.entityAudio.PlayOneShot(levelUpSound);
        Instantiate(levelUpFX, this.gameObject.transform);
    }

}

