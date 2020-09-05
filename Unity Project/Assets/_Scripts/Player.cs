using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{

    public Entity entity;

    [Header("Player Regen System")]
    private bool regenHPEnabled = false;
    private float regenHPTime = 5f;

    [Header("Player UI")]
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    [Header("Exp")]
    public int currentExp = 0;
    public int expLeft = 50;
    public GameObject levelUpFX;
    public AudioClip levelUpSound;
    
    void Start() {
        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;

        entity.damage = 50;
        entity.fireRate = 1;
        entity.speed = 3;
        
        StartCoroutine(RegenHealth());
    }    

    void Update() {
        if (entity.dead) return;

        if (entity.currentHealth <= 0) Die();
        
        NameUI();
        HealthUI();
        LevelUI();
    }

    private void NameUI() {
       nameText.text = entity.name;
    }   

    private void HealthUI() {
        hpSlider.value = entity.currentHealth;
    }     

    private void LevelUI() {
        levelText.text = "Lvl " + entity.level; 
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

    void Die () {
        entity.dead = true;
        entity.currentHealth = 0;
        entity.target = null;
        Destroy(this.gameObject);

        StopAllCoroutines();
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

            entity.damage += 10;
            entity.resistence += 5;
        }
        entity.currentHealth = entity.maxHealth;

        entity.entityAudio.PlayOneShot(levelUpSound);
        Instantiate(levelUpFX, this.gameObject.transform);
    }

}

