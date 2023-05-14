using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject GameManager;
    private GameManegar gameManegar;

    private void Start()
    {
        gameManegar = GameManager.GetComponent<GameManegar>();
    }
    void Update()
    {
        Debug.Log(gameManegar.Points);
        scoreText.text = gameManegar.Points.ToString();
      
    }



    public void DeactivatePanel()
    {
        gameObject.SetActive(false);
    }

    public void RestartLevel()
    {

        DeactivatePanel();
        gameManegar.realeseSlow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
