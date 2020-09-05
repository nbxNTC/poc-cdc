using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [Header("Controller")]
    public Entity entity = new Entity();

    [Header("UI")]
    public Slider healthSlider;

    [Header("Monster Regen System")]
    private float regenHPTime = 0.1f;

    [Header("Exp")]
    private int expFeed = 100;

    private Rigidbody2D rb;

    void Start () {        
        rb = gameObject.GetComponent<Rigidbody2D>();

        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;

        entity.damage = 10;
        entity.canAttack = true;

        healthSlider.value = entity.currentHealth;
        
        StartCoroutine(RegenHealth());
    }

    void Update () {
        if (entity.dead) return;

        if (entity.currentHealth <= 0) Die();

        healthSlider.value = entity.currentHealth;
    }

    IEnumerator RegenHealth() {
        while(true) {
            if (entity.currentHealth < entity.maxHealth) {
                entity.currentHealth++;
                yield return new WaitForSeconds(regenHPTime);
            } else {
                yield return null;
            }
        }
    }

    void Die () {
        entity.target.GetComponent<Player>().GainExp(expFeed);
        entity.currentHealth = 0;
        entity.dead = true;
        entity.target = null;
        Destroy(this.gameObject);

        StopAllCoroutines();
    }

    IEnumerator AttackRoutine(Player player) {
        if (entity.canAttack) {
            player.entity.currentHealth -= entity.damage;

            entity.canAttack = false;
            yield return new WaitForSeconds(2f);
            entity.canAttack = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Player player = collision.GetComponent<Player>();
            StartCoroutine(AttackRoutine(player));
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Player player = collision.GetComponent<Player>();
            player.entity.target = this.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Player player = collision.GetComponent<Player>();
            player.entity.target = null;
            entity.target = null;
        }
    }
}