using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
  {
    int nextScene = 1;
    PlayerPrefs.SetInt("scene", nextScene);
    SceneManager.LoadScene(nextScene);
  }

  public void LoadGame()
  {
    int nextScene = PlayerPrefs.GetInt("scene");
    SceneManager.LoadScene(nextScene == 0 ? 1 : nextScene);
  }

  public void QuitGame()
  {
    Application.Quit();
  }

}
