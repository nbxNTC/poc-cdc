﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
  public Slider hpSlider;

  public void SetHUD(Entity entity)
  {
    hpSlider.maxValue = entity.maxHealth;
    hpSlider.value = entity.currentHealth;
  }

  public void SetHP(int hp)
  {
    hpSlider.value = hp;
  }
}
