using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

    private Player player;
    public CameraMovement cameraMovement;
    public GameObject loadingUI;

    void Update() {
        if (current != null) {
            dialogText.text = current.text;
        } else {
            dialogText.text = "";
        }
    }

    public void StartDialog(DialogModel initialDialog, Player player) {    
        this.player = player;
        this.player.canMove = false;
        dialogUI.SetActive(true);
        current = initialDialog;
    }

    public void ExitDialog() {
        dialogUI.SetActive(false);
        player.canMove = true;
    }

    public void onNextButton() {
        if (current.next != null) {
            current = current.next;
        } else {
            if (current.goToNextMap) {
                loadingUI.SetActive(true);

                cameraMovement.maxPosition = current.nextMaxPosition;
                cameraMovement.minPosition = current.nextMinPosition;

                player.transform.position = new Vector2(-17, -44);

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
        if (current.back != null) {
            current = current.back;
        } else {
            ExitDialog();
        }
    }
}

