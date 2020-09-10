using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public void SetHUD(Entity entity) {
        nameText.text = entity.name;
        levelText.text = "Lvl" + entity.level.ToString();
        hpSlider.maxValue = entity.maxHealth;
        hpSlider.value = entity.currentHealth;
    }

    public void SetHP(int hp) {
        hpSlider.value = hp;
    }
}
