using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour
{
    public static int score=0;
    public static int livesSaved = 0;
    public static int mistakenKills = 0;
    public static int maxKillsLimit = 5;

    public Text txtScore;
    public Text txtLivesSaved;
    public Text txtMistakenKills;

    public static float startTime;
    // Start is called before the first frame update
    void Start()
    {
        txtMistakenKills.text = mistakenKills + "/" + maxKillsLimit;
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score += 1;
        txtScore.text = score+"";
    }

    public void updateLivesSaved()
    {
        livesSaved += 1;
        txtLivesSaved.text= livesSaved + "";
    }
    public void updateMistakenKills()
    {
        mistakenKills += 1;
        txtMistakenKills.text= mistakenKills + "/"+ maxKillsLimit;
    }
}
