using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Entity {
    
    [Header("Name")]
    public string name;

    [Header("Health")]
    public int currentHealth;
    public int maxHealth;
    
    [Header("Mana")]
    public int currentMana;
    public int maxMana;

    [Header("Stats")]
    public int level = 0;
    public int resistence = 1;
    public int damage = 1;
    public float speed = 2f;

    [Header("Combat")]
    public float attackDistance = 0.5f;
    public float attackTimer = 1f;
    public float cooldown = 2;
    public bool inCombat = false;
    public GameObject target;
    public bool combatCoroutine = false;
    public bool dead = false;

    [Header("Component")]
    public AudioSource entityAudio;
}
