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
    public int resistence;
    public int damage;
    public float speed;

    [Header("Component")]
    public AudioSource entityAudio;
}
