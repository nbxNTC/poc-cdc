using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Entity {

    [Header("Health")]
    public int currentHealth = 100;
    public int maxHealth = 100;

    [Header("Stats")]
    public int level = 0;
    public int damage = 100;
    public float speed = 2.5f;

    [Header("Component")]
    public AudioSource entityAudio;
}
