using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10;

    private Rigidbody playerRB;

    public GameObject projectile;
    public GameObject gun;
    public Transform projectileOrigin;

    private AudioSource playerAudio;
    public AudioClip teleportBetweenTowersAudio;
    public AudioClip teleportUp;
    public AudioClip teleportDown;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.isPaused && !GameOverScript.gameOver)
        {
            
            TeleportBetweenLevels();
            TeleportBetweenTowers();
            ShootLaser();
            MovePlayer();
            LimitMovementLeftTower();
            LimitMovementRightTower();
        }
        else
        {
            projectile.SetActive(false);//to prevent small bug that shoots the laser when pause is pressed.
        }

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
    {   if(transform.position.x < 0)
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

    
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(speed * horizontalInput * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime));




    }

    void TeleportBetweenLevels()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && 4.5 < transform.position.y)
        {
            playerAudio.PlayOneShot(teleportDown);
            transform.position = new Vector3(transform.position.x, transform.position.y - 8.1f, transform.position.z);
        }

        if (Input.GetButtonDown("Jump") && transform.position.y < 19)
        {
            playerAudio.PlayOneShot(teleportUp);
            transform.position = new Vector3(transform.position.x, transform.position.y + 8.1f, transform.position.z);
        }
    }

    void TeleportBetweenTowers()
    {
        if (Input.GetKeyDown(KeyCode.E) && transform.position.x < 0)
        {
            playerAudio.PlayOneShot(teleportBetweenTowersAudio);
            transform.position = new Vector3(25, transform.position.y, -7);
        }
        if (Input.GetKeyDown(KeyCode.Q) && transform.position.x > 0)
        {
            playerAudio.PlayOneShot(teleportBetweenTowersAudio);
            transform.position = new Vector3(-22, transform.position.y, -7);
        }
    }

    void ShootLaser()
    {
        //Activate Laser
        if (Input.GetButtonDown("Fire1"))
        {
            projectile.SetActive(true);
        }


        //Deactivate Laser
        if (Input.GetButtonUp("Fire1"))
        {
            projectile.SetActive(false);
        }
    }
}
