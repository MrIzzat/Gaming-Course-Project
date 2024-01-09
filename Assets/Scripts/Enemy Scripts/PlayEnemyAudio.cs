using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnemyAudio : MonoBehaviour
{
    private AudioSource enemyAudio;
    //success audio clips
    public AudioClip enemyKilled;
    public AudioClip civilianSaved;
    //Wrong audio clips
    public AudioClip civilianKilled;
    public AudioClip enemySaved;
    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playEnemyKilled()
    {
        enemyAudio.PlayOneShot(enemyKilled);
    }

    public void playCivilianSaved()
    {
        enemyAudio.PlayOneShot(civilianSaved);

    }

    public void playCivilianKilled()
    {
        enemyAudio.PlayOneShot(civilianKilled);
    }

    public void playEnemySaved()
    {
        enemyAudio.PlayOneShot(enemySaved);

        
    }

}
