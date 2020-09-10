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
    public int resistence = 2;
    public int damage = 10;
    public float speed = 3f;

    [Header("Component")]
    public AudioSource entityAudio;
}
