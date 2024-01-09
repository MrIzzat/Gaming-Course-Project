using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Button btnPause;

    public GameObject pauseMenu;

    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        btnPause.onClick.AddListener(pauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    private void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        isPaused = true;
    }
}
