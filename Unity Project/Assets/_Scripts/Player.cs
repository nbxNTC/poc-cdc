﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{

    public Entity entity;

    [Header("Player Regen System")]
    public bool regenHPEnabled = false;
    public float regenHPTime = 5f;

    [Header("Player UI")]
    public Image health1;
    public Image health2;
    public Image health3;
    
    void Start() {
        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;
        StartCoroutine(RegenHealth());
    }    

    void Update() {
        HealthUI();
        Teste();
    }

    private void Teste() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            entity.currentHealth--;
        }
    }

    private void HealthUI() {
        if (entity.currentHealth == 3) {
            health3.enabled = true;
            health2.enabled = true;
            health1.enabled = true;
        } else if (entity.currentHealth == 2) {
            health3.enabled = false;
            health2.enabled = true;
            health1.enabled = true;
        } else if (entity.currentHealth == 1) {
            health3.enabled = false;
            health2.enabled = false;
            health1.enabled = true;
        } else {
            health3.enabled = false;
            health2.enabled = false;
            health1.enabled = false;
        }
    }

    IEnumerator RegenHealth() {
        while(true) {
            if (regenHPEnabled) {
                if (entity.currentHealth < entity.maxHealth) {
                    entity.currentHealth++;
                    yield return new WaitForSeconds(regenHPTime);
                } else {
                    yield return null;
                }
            } else {
                yield return null;
            }
        }
    }

}

