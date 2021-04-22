using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloneDialog : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public DialogModel dialog;
    public GameObject aloneDialog;
    public int id;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if (player.currentDialogId == this.id) {
              player.currentDialogId += 1;
              dialogSystem.StartDialog(dialog, player);
              aloneDialog.SetActive(false);
            }
        }
    }
}
