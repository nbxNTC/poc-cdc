using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{

  public int level;
  public int health;

  public PlayerData(Player player)
  {
    level = player.entity.level;
    health = player.entity.currentHealth;
  }

}
