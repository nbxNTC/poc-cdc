using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{   
    [Header("Dialog UI")]
    public GameObject dialogUI;
    public Text dialogText;

    [Header("Dialog Buttons")]
    public GameObject back;
    public GameObject next;

    [Header("Control")]
    public DialogModel current;

    private Player player;

    void Update() {
        if (current != null) {
            dialogText.text = current.text;
        } else {
            dialogText.text = "";
        }
    }

    public void StartDialog(DialogModel initialDialog, Player player) {    
        this.player = player;
        player.canMove = false;
        dialogUI.SetActive(true);
        current = initialDialog;
    }

    public void ExitDialog() {
        dialogUI.SetActive(false);
        player.canMove = true;
    }

    public void onNextButton() {
        if (current.next != null) {
            current = current.next;
        } else {
            ExitDialog();
        }
    }

    public void onBackButton() {
        if (current.back != null) {
            current = current.back;
        } else {
            ExitDialog();
        }
    }
}

