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

    void Update() {
        if (current != null) {
            dialogText.text = current.text;
        } else {
            dialogText.text = "";
        }
    }

    public void StartDialog(DialogModel initialDialog) {    
        dialogUI.SetActive(true);
        current = initialDialog;
    }

    public void ExitDialog() {
        dialogUI.SetActive(false);
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

