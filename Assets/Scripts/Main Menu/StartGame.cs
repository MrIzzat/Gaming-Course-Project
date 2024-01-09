using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button btnEasy;
    public Button btnMedium;
    public Button btnHard;


    public static int gameDifficulty=-1; //0 = easy, 1 = medium, 2 = hard
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
        Cursor.visible = true;  
        btnEasy.onClick.AddListener(EasyButton);
        btnMedium.onClick.AddListener(MediumButton);
        btnHard.onClick.AddListener(HardButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void openGamePlayScene()
    {
      
    }

    void EasyButton()
    {
        gameDifficulty = 0;
        KeepScore.maxKillsLimit = 7;
        openGamePlayScene();
        SceneManager.LoadScene("Easy");
    }
    
    void MediumButton()
    {
        gameDifficulty = 1;
        KeepScore.maxKillsLimit = 5;
        openGamePlayScene();
        SceneManager.LoadScene("Medium");
    }
    
    void HardButton()
    {
        KeepScore.maxKillsLimit = 3;
        gameDifficulty = 2;
        openGamePlayScene();
        SceneManager.LoadScene("Hard");
    }



}
