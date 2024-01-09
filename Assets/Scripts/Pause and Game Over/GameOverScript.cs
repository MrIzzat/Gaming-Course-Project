using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    private float safeZoneHealth;
    private Slider safeZoneHealthSlider;

    public static bool gameOver = false;
    private GameObject HUD;

    public Text txtMistakenKills;
    public Text txtTime;
    public Text txtKills;
    public Text txtLivesSaved;

    public Button btnRestart;
    public Button btnMainMenu;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        safeZoneHealthSlider = GameObject.Find("Safe Zone Health").GetComponent<Slider>();
        btnRestart.onClick.AddListener(RestartGame);
        btnMainMenu.onClick.AddListener(MainMenu);
        HUD = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        safeZoneHealth = safeZoneHealthSlider.value;
        if (safeZoneHealth <= 0 || KeepScore.mistakenKills >= KeepScore.maxKillsLimit)
        {
            Cursor.visible = true;

            gameOver = true;
            gameOverUI.SetActive(true);
            HUD.SetActive(false);
            Time.timeScale = 0;

            if (((int)((Time.time - KeepScore.startTime) % 60))<10)
            {
                txtTime.text = ((int)((Time.time - KeepScore.startTime) / 60)) + ":0" + ((int)((Time.time - KeepScore.startTime) % 60));
            }
            else
            {
                txtTime.text = ((int)((Time.time - KeepScore.startTime) / 60)) + ":" + ((int)((Time.time - KeepScore.startTime) % 60));
            }
            
            txtMistakenKills.text = KeepScore.mistakenKills+"";
            txtKills.text = KeepScore.score+"";
            txtLivesSaved.text = KeepScore.livesSaved + "";


        }
    }
    private void RestartGame()
    { 
        HUD.SetActive(true);
        gameOverUI.SetActive(false);
        RestartGameScript.restartGame(1);
    }
    private void MainMenu()
    {
        RestartGameScript.restartGame(3);
    }
}
