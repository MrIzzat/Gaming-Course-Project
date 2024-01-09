using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrower : MonoBehaviour
{
    public GameObject spearPrefab;
    public Transform projectileOrigin;
    private float spearSpeed = 90;

    private AudioSource spearAudio;
    public AudioClip throwAudio;

    private float throwTime;
    private float cooldown=1.5f;
    private bool canThrow;
    // Start is called before the first frame update
    void Start()
    {
        spearAudio = GetComponent<AudioSource>();
        Physics.gravity *= 0.75f;
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.52f, 0.54f, 0));
        Physics.Raycast(ray, Mathf.Infinity);
        if (Input.GetButtonDown("Fire1") && !GameOverScript.gameOver && !PauseGame.isPaused&& canThrow)
        {
            throwTime = Time.time;
            canThrow = false;

            spearAudio.PlayOneShot(throwAudio);
            GameObject spear = Instantiate(spearPrefab, projectileOrigin.position, projectileOrigin.rotation);
            Rigidbody spearRb = spear.GetComponent<Rigidbody>();
            Vector3 spearTrajectory = (ray.GetPoint(999999999999999999f) - projectileOrigin.position).normalized;
            spear.transform.LookAt(ray.GetPoint(999999999999999999f));

            spear.transform.Rotate(Vector3.right, 90f);


            spearRb.AddForce(spearTrajectory * spearSpeed, ForceMode.Impulse);
        }


        if ( cooldown < Time.time - throwTime)
        {

            canThrow = true;
        }
    }
}
