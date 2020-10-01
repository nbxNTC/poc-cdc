using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public DialogModel dialog;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();

            dialogSystem.StartDialog(dialog, player);
        }
    }
}
