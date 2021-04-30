using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloneDialog : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public DialogModel dialog;
    public GameObject aloneDialog;
    public int id;
    
    public bool willDisableObject = false;
    public GameObject objectToDisable;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();

            if (this.id == -1) {
                dialogSystem.StartDialog(dialog, player);
                aloneDialog.SetActive(false);
            }

            if (this.id == player.currentDialogId) {
                player.currentDialogId += 1;
                dialogSystem.StartDialog(dialog, player);

                if (willDisableObject) objectToDisable.SetActive(false);

                aloneDialog.SetActive(false);
            }
        }
    }
}
