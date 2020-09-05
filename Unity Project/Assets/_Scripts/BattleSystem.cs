﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    Player player;
    Monster monster;

    void Start() {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle() {
        
    }
}
