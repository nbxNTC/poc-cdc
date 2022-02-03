using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [Header("Entity")]
  public Entity entity;

  [Header("Controller")]
  public bool canMove = true;
  public int currentDialogId = 1;

  [Header("Level")]
  public int currentExp = 0;
  public int expLeft = 50;
  public GameObject levelUpFX;
  public AudioClip levelUpSound;

  [Header("Choices")]
  public bool firstChoice;

  void Start() { }

  public void SavePlayer()
  {
    SaveSystem.SavePlayer(this);
  }

  public void LoadPlayer()
  {
    PlayerData data = SaveSystem.LoadPlayer();

    entity.level = data.level;
    entity.currentHealth = data.health;

    Debug.Log(data.level);
    Debug.Log(data.health);
  }

  public bool TakeDamage(int damage)
  {
    entity.currentHealth -= damage;

    if (entity.currentHealth <= 0) return true;
    else return false;
  }

  public void Heal(int health)
  {
    entity.currentHealth += health;

    if (entity.currentHealth > entity.maxHealth)
      entity.currentHealth = entity.maxHealth;
  }

  public void GainExp(int amount)
  {
    currentExp += amount;
    if (currentExp >= expLeft) LevelUp();
  }

  public void LevelUp()
  {
    while (currentExp >= expLeft)
    {
      currentExp -= expLeft;
      expLeft += 50;
      entity.level++;

      entity.damage += 7;
    }
    entity.currentHealth = entity.maxHealth;

    entity.entityAudio.PlayOneShot(levelUpSound);
    Instantiate(levelUpFX, this.gameObject.transform);
  }

}

