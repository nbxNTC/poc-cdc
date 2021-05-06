﻿using System.Collections;
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

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();

            if (this.id == -1) {
                dialogueSystem.StartDialog(dialogue, player);
                dialogueObject.SetActive(false);
            }

            if (this.id == player.currentDialogId) {
                player.currentDialogId += 1;
                dialogueSystem.StartDialog(dialogue, player);
                dialogueObject.SetActive(false);
            }
        }
    }
}
