using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilePlayerGun : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 5;

    private AudioSource playerAudio;
    public AudioClip teleportBetweenTowersAudio;
    public AudioClip teleportUp;
    public AudioClip teleportDown;


    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.isPaused && !GameOverScript.gameOver)
        {
            MovePlayer();
            LimitMovementLeftTower();
            LimitMovementRightTower();
        }

    }
    void MovePlayer()
    {
        transform.Translate(new Vector3(speed * horizontalInput * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime));


    }

    private void LimitMovementRightTower()
    {
        if (transform.position.x > 0)
        {
            if (transform.position.z >= -3.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -3.5f);
            }
            if (transform.position.z <= -10.98)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -10.98f);
            }
            if (transform.position.x <= 18.55)
            {
                transform.position = new Vector3(18.55f, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= 26.15)
            {
                transform.position = new Vector3(26.15f, transform.position.y, transform.position.z);
            }
        }
    }

    private void LimitMovementLeftTower()
    {
        if (transform.position.x < 0)
        {
            if (transform.position.z >= -3.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -3.5f);
            }
            if (transform.position.z <= -10.98)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -10.98f);
            }
            if (transform.position.x >= -18.55)
            {
                transform.position = new Vector3(-18.55f, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -26.15)
            {
                transform.position = new Vector3(-26.15f, transform.position.y, transform.position.z);
            }
        }

    }
    public void moveRightBtnDown()
    {
        horizontalInput = 1;
    }
    public void moveRightBtnUp()
    {
        horizontalInput = 0;
    }

    public void moveLeftBtnDown()
    {
        horizontalInput = -1;
    }
    public void moveLeftBtnUp()
    {
        horizontalInput = 0;
    }

    public void moveUpBtnDown()
    {
        verticalInput = 1;
    }
    public void moveUpBtnUp()
    {
        verticalInput = 0;
    }

    public void moveDownBtnDown()
    {
        verticalInput = -1;
    }
    public void moveDownBtnUp()
    {
        verticalInput = 0;
    }






    public void TeleportUp()
    {
        if (transform.position.y < 19)
        {
            playerAudio.PlayOneShot(teleportUp);
            transform.position = new Vector3(transform.position.x, transform.position.y + 8.1f, transform.position.z);
        }

    }

    public void TeleportDown()
    {
        if (4.5 < transform.position.y)
        {
            playerAudio.PlayOneShot(teleportDown);
            transform.position = new Vector3(transform.position.x, transform.position.y - 8.1f, transform.position.z);
        }
        
    }

    public void TeleportRight()
    {
        if (transform.position.x < 0)
        {
            playerAudio.PlayOneShot(teleportBetweenTowersAudio);
            transform.position = new Vector3(25, transform.position.y, -7);
        }
    }

    public void Teleportleft()
    {
        if (transform.position.x > 0)
        {
            playerAudio.PlayOneShot(teleportBetweenTowersAudio);
            transform.position = new Vector3(-22, transform.position.y, -7);
        }
    }

    public void ZoomIn()
    {
        Camera.main.fieldOfView = 15;
    }

    public void ZoomOut()
    {
        Camera.main.fieldOfView = 30;
    }
}
