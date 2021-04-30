using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [Header("Dialogue UI")]
    public GameObject dialogUI;
    public Text dialogText;

    [Header("Dialogue Buttons")]
    public GameObject back;
    public GameObject next;

    [Header("Control")]
    private Player player;
    public CameraMovement cameraMovement;
    public GameObject loadingUI;
    public bool hasNextPosition = false;
    public float nextXPosition;
    public float nextYPosition;
    public Vector2 nextMaxPosition;
    public Vector2 nextMinPosition;

    [Header("Dialogue Informations")]
    public int id = -1;
    public GameObject dialogueObject;
    public int dialogueIndex = 0;
    public List<string> dialogues;
    public bool willDisableObject = false;
    public GameObject objectToDisable;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();

            if (this.id == -1) {
                StartDialog(player);
                dialogueObject.SetActive(false);
            }

            if (this.id == player.currentDialogId) {
                player.currentDialogId += 1;
                StartDialog(player);

                if (willDisableObject) objectToDisable.SetActive(false);

                dialogueObject.SetActive(false);
            }
        }
    }

    void Update() {
        if (dialogueIndex < dialogues.Count) {
            dialogText.text = dialogues[dialogueIndex];
        } else {
            dialogText.text = "";
        }
    }

    public void StartDialog(Player player) {    
        this.player = player;
        this.player.canMove = false;
        dialogUI.SetActive(true);
    }

    public void ExitDialog() {
        dialogUI.SetActive(false);
        player.canMove = true;
    }

    public void onNextButton() {
        if (dialogueIndex < (dialogues.Count - 1)) {
            dialogueIndex += 1;

            Debug.Log("Teste");
            Debug.Log(dialogues);
            Debug.Log(dialogueIndex);
            Debug.Log(dialogues[dialogueIndex]);
        } else {
            if (hasNextPosition) {
                loadingUI.SetActive(true);

                cameraMovement.maxPosition = nextMaxPosition;
                cameraMovement.minPosition = nextMinPosition;

                player.transform.position = new Vector2(nextXPosition, nextYPosition);

                StartCoroutine(DisableLoading());
            }

            ExitDialog();
        }
    }

    IEnumerator DisableLoading () {
        yield return new WaitForSeconds(4);

        loadingUI.SetActive(false);
    }

    public void onBackButton() {
        if (dialogueIndex > 0) {
            dialogueIndex -= 1;
        } else {
            ExitDialog();
        }
    }
}
