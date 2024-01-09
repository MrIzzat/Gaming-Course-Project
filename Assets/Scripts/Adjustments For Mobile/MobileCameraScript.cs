using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobileCameraScript : MonoBehaviour
{
    public GameObject player;

    private float rotationSpeed = 0.01f;
    private float mouseXInput;
    private float mouseYInput;
    private Vector3 offset = new Vector3(1.5f, 1f, -4.5f);
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 newPostion = player.transform.position + offset;
        //transform.position = newPostion;



    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseGame.isPaused && !GameOverScript.gameOver)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    mouseXInput = touch.deltaPosition.x;
                    mouseYInput = touch.deltaPosition.y;
                }
            }
            Cursor.visible = false;

            rotateWithPlayer();
            limitRotation();
        }
    }
    void rotateWithPlayer()
    {
        player.transform.Rotate(new Vector3(0, mouseXInput * rotationSpeed * 10, 0));
        transform.Rotate(new Vector3(mouseYInput * (-rotationSpeed * 10), 0, 0));

        mouseYInput=0;
        mouseXInput=0;

    }

    void limitRotation()
    {
        // localEulerAngles returns the angle as a value between 0,360 that's why there had to be a limit to set the upper bound and lower bound of the object
        if (transform.localEulerAngles.x > 10 && transform.localEulerAngles.x < 180)
        {
            transform.localEulerAngles = new Vector3(10, 0, 0);
        }

        if (transform.localEulerAngles.x < 330 && transform.localEulerAngles.x > 180)
        {

            transform.localEulerAngles = new Vector3(330, 0, 0);
        }
    }


}
