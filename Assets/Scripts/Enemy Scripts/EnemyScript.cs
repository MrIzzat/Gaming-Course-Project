using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int number;
    public Text txtNumber;
    public Canvas cnvNumber;

    public bool displayEnemyNumber = false;
    public bool specialEnemy = false;

    private float displayTime = 0.5f;
    private float timeDisplayed = 0f;

    public float zSpeed;
    public float ySpeed;

    private GenerateQuestions questions;
    private KeepScore keepScoreScript;
    private SafeZoneHealth safeZoneHealth;



    private PlayEnemyAudio enemyAudioScript;

    public GameObject successParticles;
    public GameObject failParticles;
    // Start is called before the first frame update
    void Start()
    {
        questions = GameObject.Find("Generate Questions").GetComponent<GenerateQuestions>();
        keepScoreScript = GameObject.Find("HUD").GetComponent<KeepScore>();
        safeZoneHealth = GameObject.Find("Safe Zone Health").GetComponent<SafeZoneHealth>();

        enemyAudioScript = GameObject.Find("PlayEnemyAudio").GetComponent<PlayEnemyAudio>();

        if (!specialEnemy)
        {
            number = Random.Range(-145, 145);
           
        }
        txtNumber.text = number + "";

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0, -ySpeed * Time.deltaTime, -zSpeed * Time.deltaTime));

        if (displayEnemyNumber)
        {
            displayNumber();
        }

        destroyEnemyOutOfBounds();


    }
    void destroyEnemyOutOfBounds()
    {
        if (transform.position.z < -26.5)
        {
            if (questions.answer != number)
            {
                keepScoreScript.updateLivesSaved();
                enemyAudioScript.playCivilianSaved();
                GameObject particles = Instantiate(successParticles);
                particles.transform.position = transform.position;
                particles.GetComponent<ParticleSystem>().Play();
                Destroy(particles, 2.0f);

            }
            else
            {
                enemyAudioScript.playEnemySaved();
                safeZoneHealth.updateHealth();
                GameObject particles = Instantiate(failParticles);
                particles.transform.position = transform.position;
                particles.GetComponent<ParticleSystem>().Play();
                Destroy(particles, 2.0f);
            }
            Destroy(gameObject);
        }
    }
    public void displayNumber()
    {
        timeDisplayed += Time.deltaTime;
        if(timeDisplayed <= displayTime)
        {
            cnvNumber.gameObject.SetActive(true);
            cnvNumber.transform.LookAt(GameObject.Find("Player").transform.position);
        }
        else
        {
            timeDisplayed = 0;
            displayEnemyNumber = false;
            cnvNumber.gameObject.SetActive(false);
        }
       
    }

    public void updateNumber(int newNumber)
    {
        number = newNumber;
    }



}
