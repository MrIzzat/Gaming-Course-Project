using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int seconds = (int) (Time.time - KeepScore.startTime ) % 60;
        int minutes = (int) (Time.time - KeepScore.startTime) / 60;

        if (seconds < 10)
        {
            timer.text = minutes + ":0" + seconds;
        }
        else
        {
            timer.text = minutes + ":" + seconds;
        }
        
    }
}
