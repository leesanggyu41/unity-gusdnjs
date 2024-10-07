using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject loadingcreen;
    public string sceneName;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playGame()
    {
        loadingcreen.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Debug.Log("game over");
        Application.Quit();
    }

}