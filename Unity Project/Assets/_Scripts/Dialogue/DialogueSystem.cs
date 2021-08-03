using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{   
    [Header("Dialogue UI")]
    public GameObject dialogueUI;
    public GameObject choiceUI;
    public Text dialogueText;
    public Text firstChoiceText;
    public Text secondChoiceText;
    public GameObject loadingUI;

    [Header("Dialogue Buttons")]
    public GameObject next;

    [Header("Dialogue Control")]
    public Dialogue current;
    private Player player;
    public CameraMovement cameraMovement;

    void Update() {
        if (current != null) {
            if (current.choiceId == 0) {
                dialogueText.text = current.dialogues[current.dialogueIndex];
            } else {
                firstChoiceText.text = current.firstOption;
                secondChoiceText.text = current.secondOption;
            }
        } else {
            dialogueText.text = "";
            firstChoiceText.text = "";
            secondChoiceText.text = "";
        }
    }

    public void StartDialog(Dialogue dialogue, Player player) {    
        this.player = player;
        this.player.canMove = false;

        if (dialogue.choiceId == 0) dialogueUI.SetActive(true);
        if (dialogue.choiceId != 0) choiceUI.SetActive(true);

        current = dialogue;
    }

    public void ExitDialog() {
        if (current.willEnableObject) current.objectToEnable.SetActive(true);
        if (current.willDisableObject) current.objectToDisable.SetActive(false);

        if (current.hasNextScene) {
            loadingUI.SetActive(true);

            player.SavePlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            StartCoroutine(DisableLoading());
        }

        if (current.hasNextPosition) {
            loadingUI.SetActive(true);

            if (current.hasNextCameraPositions) {
                cameraMovement.maxPosition = current.nextMaxPosition;
                cameraMovement.minPosition = current.nextMinPosition;
            }

            player.transform.position = new Vector2(current.nextXPosition, current.nextYPosition);
            StartCoroutine(DisableLoading());
        }

        if (current.choiceId == 0) dialogueUI.SetActive(false);
        else choiceUI.SetActive(false);

        player.canMove = true;
    }

    public void onNextButton() {
        if (current.dialogueIndex < current.dialogues.Count - 1) {
            current.dialogueIndex += 1;
        } else {
            ExitDialog();
        }
    }

    public void chooseFirst() {
        if (current.choiceId == 1) player.firstChoice = false; // Save all friends
        ExitDialog();
    }

    public void chooseSecond() {
        if (current.choiceId == 1) player.firstChoice = true; // Let them be beaten
        ExitDialog();
    }

    IEnumerator DisableLoading () {
        yield return new WaitForSeconds(4);

        loadingUI.SetActive(false);
    }
}

