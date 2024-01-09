using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private KeepScore keepScoreScript;
    private GenerateQuestions questionsScript;
    private AudioSource projectileAudio;
    public AudioClip laserAudio;

    private PlayEnemyAudio enemyAudioScript;

    public GameObject successParticles;
    public GameObject failParticles;
    public GameObject explosionParticles;
    // Start is called before the first frame update
    void Start()
    {
        keepScoreScript = GameObject.Find("HUD").GetComponent<KeepScore>();
        questionsScript = GameObject.Find("Generate Questions").GetComponent<GenerateQuestions>();
        projectileAudio = GetComponent<AudioSource>();

        enemyAudioScript = GameObject.Find("PlayEnemyAudio").GetComponent<PlayEnemyAudio>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, 5);

        if (gameObject.activeSelf == true)
        {
            projectileAudio.PlayOneShot(laserAudio);
        }
        else
        {
            projectileAudio.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            GameObject explosion = Instantiate(explosionParticles);
            explosion.transform.position = collision.GetContact(0).point;
            explosion.GetComponent<ParticleSystem>().Play();
            Destroy(explosion, 2.0f);

            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();

            if (enemyScript.number == questionsScript.answer)
            {

                keepScoreScript.updateScore();
                GenerateQuestions.solved = true;
                enemyAudioScript.playEnemyKilled();
                GameObject particles = Instantiate(successParticles);
                particles.transform.position = collision.GetContact(0).point;
                particles.GetComponent<ParticleSystem>().Play();
                Destroy(particles, 2.0f);


            }
            else
            {
                enemyAudioScript.playCivilianKilled();
                keepScoreScript.updateMistakenKills();
                GameObject particles = Instantiate(failParticles);
                particles.transform.position = collision.GetContact(0).point;
                particles.GetComponent<ParticleSystem>().Play();
                Destroy(particles, 2.0f);
            }
            Destroy(collision.gameObject);

        }
        
    }

}