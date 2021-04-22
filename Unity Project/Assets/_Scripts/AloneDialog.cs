using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloneDialog : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public DialogModel dialog;
    public GameObject aloneDialog;
    public bool hideWhenFinished = false;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();
            dialogSystem.StartDialog(dialog, player);
            aloneDialog.SetActive(false);
        }
    }
}
