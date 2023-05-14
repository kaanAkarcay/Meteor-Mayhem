using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegar : MonoBehaviour
{
    [SerializeField]private float slowness = 10f;
    [SerializeField] private float SlowTime = 1f;
    [SerializeField] private GameObject gameOverPanel;
    public int Points;
    public int ammo;
    public float TimeBetweenWaves = 2f;
    public int spawnNumber = 1;
    private int divider=10;
    private void Start()
    {
        Points = 0;
        ammo = 20;
        divider = 5;
    }
    public void IncreasePoints(int Amount)
    {
        if(!gameOverPanel.activeSelf)
        Points += Amount;

        if (TimeBetweenWaves > 0.8f)
            TimeBetweenWaves -= 0.01f;
        if (((Points / divider) > spawnNumber)&& (spawnNumber < 4))
        {
            
            spawnNumber++;
            divider += divider;
            Debug.Log("arttı ab " + spawnNumber + " divider: "+ divider);
        }
            
    }
    public void addAmmo()
    {
        ammo += 20;
    }
    public void SpendAmmo()
    {
        ammo-=2;
    }
    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(SlowTime/slowness);

        //Time.timeScale = 1f;
       // Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Activate the UI panel
        gameOverPanel.SetActive(true);
    }

    public void realeseSlow()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
    }

   
}
