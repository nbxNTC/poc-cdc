using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("Dialog Management System")]
    public GameObject dialogueObject;
    public Dialogue dialogue;
    public DialogueSystem dialogueSystem;

    [Header("Dialogue Info")]
    public int id;
    public int dialogueIndex = 0;
    public List<string> dialogues;

    [Header("Dialogue Choice")]
    public int choiceId;
    public string firstOption;
    public string secondOption;

    [Header("Dialogue Enable/Disable Object")]
    public bool willEnableObject = false;
    public GameObject objectToEnable;
    public bool willDisableObject = false;
    public GameObject objectToDisable;

    [Header("Dialogue Next Position")]
    public bool hasNextPosition = false;
    public float nextXPosition;
    public float nextYPosition;

    [Header("Dialogue Next Camera Positions")]
    public bool hasNextCameraPositions = false;
    public Vector2 nextMaxPosition;
    public Vector2 nextMinPosition;

    [Header("Dialogue Next Scene")]
    public bool hasNextScene = false;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();

            if (this.id == -1) {
                dialogueSystem.StartDialog(dialogue, player);
                dialogueObject.SetActive(false);
            }

            if (this.id == player.currentDialogId) {
                if (this.choiceId == 0) player.currentDialogId += 1;
                else player.currentDialogId += 2;
                dialogueSystem.StartDialog(dialogue, player);
                dialogueObject.SetActive(false);
            }
        }
    }
}
