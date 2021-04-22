using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{   
    [Header("Battle Dialogue")]
    public Text dialogueText;

    [Header("Battle UI")]
    public GameObject battleUI;

    [Header("Battle Buttons")]
    public GameObject attackButton;
    public GameObject healButton;

    [Header("HUDs")]
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    
    [Header("State")]
    BattleState state;

    [Header("References")]
    Player player;
    Monster monster;

    public void StartBattle(Player player, Monster monster) {
        this.player = player;
        this.monster = monster;

        player.canMove = false;

        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() {
        battleUI.SetActive(true);    

        dialogueText.text = "Um " + monster.entity.name + " apareceu...";

        playerHUD.SetHUD(player.entity);
        enemyHUD.SetHUD(monster.entity);
        
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack() {
        bool isDead = monster.TakeDamage(player.entity.damage);

        enemyHUD.SetHP(monster.entity.currentHealth);
        dialogueText.text = "O ataque foi realizado!";

        yield return new WaitForSeconds(2f);

        if (isDead) {
            state = BattleState.WON;
            Destroy(monster.gameObject);
            EndBattle();
        } else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal() {
        player.Heal(10);

        playerHUD.SetHP(player.entity.currentHealth);
        dialogueText.text = "Você foi curado!";

        yield return new WaitForSeconds(2f);

        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn() {
        dialogueText.text = monster.entity.name + " atacou!";

        attackButton.SetActive(false);
        healButton.SetActive(false);

        yield return new WaitForSeconds(1f);

        bool isDead = player.TakeDamage(monster.entity.damage);
        playerHUD.SetHP(player.entity.currentHealth);

        yield return new WaitForSeconds(1f);

        if (isDead) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle() {
        if (state == BattleState.WON) {
            dialogueText.text = "Você venceu a batalha!";
            
            player.GainExp(monster.expFeed);

            player.canMove = true;
        } else if (state == BattleState.LOST) {
            dialogueText.text = "Você foi derrotado!";
        }

        battleUI.SetActive(false);
    }

    void PlayerTurn() {
        dialogueText.text = "Escolha uma ação...";
        
        attackButton.SetActive(true);
        healButton.SetActive(true);
    }

    public void onAttackButton() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
    }

    public void onHealButton() {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerHeal());
    }
}

