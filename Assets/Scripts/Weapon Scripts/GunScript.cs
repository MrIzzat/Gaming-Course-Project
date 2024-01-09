using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform projectileOrigin;
    private float bulletSpeed=20;

    private AudioSource gunAudio;
    public AudioClip bulletFireAudio;
    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.52f, 0.54f, 0));
        Physics.Raycast(ray, Mathf.Infinity);

        if (Input.GetButtonDown("Fire1")&&!GameOverScript.gameOver&&!PauseGame.isPaused)
        {
            gunAudio.PlayOneShot(bulletFireAudio);
            GameObject bullet = Instantiate(bulletPrefab, projectileOrigin.position, projectileOrigin.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            Vector3 bulletTrajectory = (ray.GetPoint(999999999999999999f) - projectileOrigin.position).normalized;
            bullet.transform.LookAt(ray.GetPoint(999999999999999999f));

            bullet.transform.Rotate(Vector3.up, 90f);

           bulletRb.AddForce(bulletTrajectory * bulletSpeed, ForceMode.Impulse);
        }
    }
}
