using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    private KeepScore keepScoreScript;
    private GenerateQuestions questionsScript;

    private PlayEnemyAudio enemyAudioScript;

    public GameObject successParticles;
    public GameObject failParticles;
    public GameObject explosionParticles;

    private float spawnTime;
    private float timeAlive;
    private float lifeTimeLength = 5f;
    // Start is called before the first frame update
    void Start()
    {
        keepScoreScript = GameObject.Find("HUD").GetComponent<KeepScore>();
        questionsScript = GameObject.Find("Generate Questions").GetComponent<GenerateQuestions>();

        enemyAudioScript = GameObject.Find("PlayEnemyAudio").GetComponent<PlayEnemyAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > spawnTime + lifeTimeLength)
        {
            Destroy(gameObject);
        }


        transform.Rotate(0, 2, 0);

     
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