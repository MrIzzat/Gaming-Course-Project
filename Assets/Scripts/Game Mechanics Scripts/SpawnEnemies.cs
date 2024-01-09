using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] spawnEnemies;

    private float spawnDelay = 2f;
    private float spawnInterval = 2f;

    private GenerateQuestions questions;

    private bool enemyWithAnswer = false;
    private float cooldown = 5f;
    private float lastSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        questions = GameObject.Find("Generate Questions").GetComponent<GenerateQuestions>();
        InvokeRepeating("Spawner", spawnDelay, spawnInterval);
        lastSpawnTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawner()
    {

        GameObject chosenEnemyToSpawn = spawnEnemies[Random.Range(0, spawnEnemies.Length)];
        float randomX = Random.Range(8f, -8f);

        Vector3 spawnPos = new Vector3(randomX
            , chosenEnemyToSpawn.transform.position.y
            , transform.position.z);




        GameObject spawnedEnemy = Instantiate(chosenEnemyToSpawn, spawnPos, chosenEnemyToSpawn.transform.rotation);

        EnemyScript spawnedEnemyScript = spawnedEnemy.GetComponent<EnemyScript>();


        if (Time.time - lastSpawnTime > cooldown)
        {
            enemyWithAnswer = true;
        }

        if(enemyWithAnswer)//spawn in enemy with the correct answer every 5 seconds
        {
            spawnedEnemyScript.updateNumber(questions.answer);
            spawnedEnemyScript.specialEnemy = true;

            lastSpawnTime= Time.time;
            cooldown = Random.Range(2.2f, 9f);
            enemyWithAnswer = false;
        }

        

        if (chosenEnemyToSpawn.name == "Eagle_Elite(Clone)")//handle animation
        {
            chosenEnemyToSpawn.GetComponent<Animator>().SetFloat("Speed", 1);
        }



    }

}
