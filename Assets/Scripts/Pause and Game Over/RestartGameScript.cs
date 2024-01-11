using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGameScript : MonoBehaviour
{
    //public static Slider safeZoneHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void restartGame(int ID)
    {
        if(ID == 0) //From Pause Menu
        {
            PauseGame.isPaused = false;
            KeepScore.score = 0;
            KeepScore.mistakenKills = 0;
            KeepScore.livesSaved = 0;
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(ID == 1)//From Game Over 
        {
            

            KeepScore.score = 0;
            KeepScore.mistakenKills = 0;
            KeepScore.livesSaved = 0;

            GameOverScript.gameOver = false;
            PauseGame.isPaused = false;

            GameObject.Find("Safe Zone Health").GetComponent<Slider>().value = 100;

            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (ID == 2)//Quit game from pause menu
        {
            PauseGame.isPaused = false;
            KeepScore.score = 0;
            KeepScore.mistakenKills = 0;
            KeepScore.livesSaved = 0;
            Time.timeScale = 1;
            SceneManager.LoadScene("Main Menu");
        }

        if( ID == 3)//Quit game from Quit Game
        {
            GameOverScript.gameOver = false;
            PauseGame.isPaused = false;

     

            KeepScore.score = 0;
            KeepScore.mistakenKills = 0;
            KeepScore.livesSaved = 0;

            Slider[] foundObjects = FindObjectsByType<Slider>(FindObjectsInactive.Include, FindObjectsSortMode.None);
     
            Slider safeZoneHealth=null;

            for (int i =0; i<foundObjects.Length;i++){
                if (foundObjects[i].gameObject.name == "Safe Zone Health") { safeZoneHealth = foundObjects[i]; }
            }


            safeZoneHealth.value = 100;



            Time.timeScale = 1;
            SceneManager.LoadScene("Main Menu");
        }
    }

}
