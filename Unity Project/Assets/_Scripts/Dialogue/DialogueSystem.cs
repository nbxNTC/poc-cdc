using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{   
    [Header("Dialogue UI")]
    public GameObject dialogueUI;
    public Text dialogueText;
    public GameObject loadingUI;

    [Header("Dialogue Buttons")]
    public GameObject next;

    [Header("Dialogue Control")]
    public Dialogue current;
    private Player player;
    public CameraMovement cameraMovement;

    void Update() {
        if (current != null) {
            dialogueText.text = current.dialogues[current.dialogueIndex];
        } else {
            dialogueText.text = "";
        }
    }

    public void StartDialog(Dialogue dialogue, Player player) {    
        this.player = player;
        this.player.canMove = false;

        dialogueUI.SetActive(true);
        current = dialogue;
    }

    public void ExitDialog() {
        dialogueUI.SetActive(false);
        player.canMove = true;
    }

    public void onNextButton() {
        if (current.dialogueIndex < current.dialogues.Count - 1) {
            current.dialogueIndex += 1;
        } else {
            if (current.willEnableObject) current.objectToDisable.SetActive(true);
            if (current.willDisableObject) current.objectToDisable.SetActive(false);

            if (current.hasNextPosition) {
                loadingUI.SetActive(true);

                if (current.hasNextCameraPositions) {
                    cameraMovement.maxPosition = current.nextMaxPosition;
                    cameraMovement.minPosition = current.nextMinPosition;
                }

                player.transform.position = new Vector2(current.nextXPosition, current.nextYPosition);
                StartCoroutine(DisableLoading());
            }

            ExitDialog();
        }
    }

    IEnumerator DisableLoading () {
        yield return new WaitForSeconds(4);

        loadingUI.SetActive(false);
    }
}

