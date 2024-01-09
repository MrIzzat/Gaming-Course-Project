using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public Button btnPlay;
    public Button btnMainMenu;
    public Button btnRestart;

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        btnRestart.onClick.AddListener(RestartGame);
        btnPlay.onClick.AddListener(UnpauseGame);
        btnMainMenu.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnpauseGame();
        }
    }


    private void RestartGame()
    {
        RestartGameScript.restartGame(0);
    }

    private void UnpauseGame()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        PauseGame.isPaused = false;
    }

    private void MainMenu()
    {
        RestartGameScript.restartGame(2);
    }
}
