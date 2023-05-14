using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ViewScore : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private GameObject GameManager;
    private GameManegar gameManegar;

    private void Start()
    {
        gameManegar = GameManager.GetComponent<GameManegar>();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = gameManegar.Points.ToString();
        ammoText.text = gameManegar.ammo.ToString();
        // Debug.Log(gameManegar.Points);
    }
}
