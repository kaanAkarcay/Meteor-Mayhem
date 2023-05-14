using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject blocPrefab;
    [SerializeField] private GameObject ammoPrefab;

    [SerializeField] private float timeBetweenWaves;


    [SerializeField] private GameObject GameManager;
    private GameManegar gameManegar;
    private float timeToSpawn = 2f;
    private void Start()
    {
        gameManegar = GameManager.GetComponent<GameManegar>();
    }


    void Update()
    {
        timeBetweenWaves = gameManegar.TimeBetweenWaves;

        if (Time.time >= timeToSpawn)
        {
            for(int i = 0; i < gameManegar.spawnNumber; i++) { 
            spawnBlocks();
                }
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void spawnBlocks()
    {
        // int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomAmmoIndex = Random.Range(0,100);
        
       
        //  Instantiate(blocPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 position = spawnPoints[randomIndex].position;
        position.x += Random.Range(-0.5f, 0.5f);

        float randomRotation = Random.Range(0f, 360f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, randomRotation);
        GameObject block = Instantiate(blocPrefab, position, rotation);

        Rigidbody2D blockRigidbody = block.GetComponent<Rigidbody2D>();
        Vector2 spinForce = new Vector2(Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        blockRigidbody.AddForce(spinForce);
        if(randomAmmoIndex>95)
        Instantiate(ammoPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
