using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Monster : MonoBehaviour
{
    [Header("Controller")]
    public Entity entity = new Entity();
    
    [Header("Patrol")]
    public Transform[] waypointList;
    public float arrivalDistance = 0.5f;
    public float waitTime = 5;

    
    Transform targetWaypoint;
    int currentWaypoint = 0;
    float lastDistanceToTarget = 0f;
    float currentWaitTime = 0f;

    [Header("Experience Reward")]
    public int rewardExperience = 10;
    public int lootGoldMin = 0;
    public int lootGoldMax = 10;

    [Header("Respawn")]
    public GameObject prefab;
    public bool respawn = true;
    public float respawnTime = 10f;

    Rigidbody2D rigidbody2D;
    Animator animator;

    private void start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;

        currentWaitTime = waitTime;
        if (waypointList.Length > 0) {
            targetWaypoint = waypointList[currentWaypoint];
            lastDistanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);
        }
    }

    private void update () {
        if (entity.dead) return;

        if (entity.currentHealth <= 0) {
            entity.currentHealth = 0;
            Die();
        }

        if (!entity.inCombat) {
            if (waypointList.Length > 0) {
                Patrol();
            } else {
                animator.SetBool("isWalking", false);
            }
        } else {
            if (entity.attackTimer > 0) entity.attackTimer -= Time.deltaTime;
            
            if (entity.attackTimer < 0) entity.attackTimer = 0;

            if (entity.target != null && entity.inCombat) {
                if(!entity.combatCoroutine) StartCoroutine(Attack());
            } else {
                entity.combatCoroutine = false;
                StopCoroutine(Attack());
            }
        }
    }

    private void OnTriggerStay2D (Collider2D collider) {
        if (collider.tag == "Player" && !entity.dead) {
            entity.inCombat = true;
            entity.target = collider.gameObject;
            entity.target.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collider) {
        if (collider.tag == "Player" ) {
            entity.inCombat = false;
            if (entity.target) {
                entity.target.GetComponent<BoxCollider2D>().isTrigger = false;
                entity.target = null;
            }
            
        }
    }

    void Patrol () {
        if (entity.dead) return;

        float distanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);

        if (distanceToTarget <= arrivalDistance || distanceToTarget >= lastDistanceToTarget) {
            animator.SetBool("isWalking", false);

            if (currentWaitTime <= 0) {
                currentWaypoint++;

                if (currentWaypoint >= waypointList.Length) currentWaypoint = 0;

                targetWaypoint = waypointList[currentWaypoint];
                lastDistanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);

                currentWaitTime = waitTime;
            } else {
                currentWaitTime -= Time.deltaTime;
            }
        } else {
            animator.SetBool("isWalking", true);
            lastDistanceToTarget = distanceToTarget;
        }

        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);

        rigidbody2D.MovePosition(rigidbody2D.position + direction * (entity.speed * Time.fixedDeltaTime));
        
    }

    IEnumerator Attack () {
        entity.combatCoroutine = true;
        while (true) {
            yield return new WaitForSeconds(entity.cooldown);

            if (entity.target != null && !entity.target.GetComponent<Player>().entity.dead) {
                float distance = Vector2.Distance(entity.target.transform.position, transform.position);
                
                if (distance <= entity.attackDistance) {
                    // Attack player
                }
            }
        }
    }

    void Die () {
        entity.dead = true;
        entity.inCombat = false;
        entity.target = null;

        animator.SetBool("isWalking", false);

        Debug.Log("O inimigo morreu: " + entity.name);

        StopAllCoroutines();
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn () {
        yield return new WaitForSeconds(respawnTime);

        GameObject newMonster = Instantiate(prefab, transform.position, transform.rotation, null);
        newMonster.name = prefab.name;
        newMonster.GetComponent<Monster>().entity.dead = false;

        Destroy(this.gameObject);
    }
}