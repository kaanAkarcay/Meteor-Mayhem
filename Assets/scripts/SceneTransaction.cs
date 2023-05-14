using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransaction : MonoBehaviour
{
    [SerializeField] string sceneName;

    [SerializeField] float delay;
    [SerializeField] private GameObject GameManager;
    private GameManegar gameManegar;

    private void Start()
    {
        gameManegar = GameManager.GetComponent<GameManegar>();
    }

    public void LoadSceneWithDelay()
    {
        Debug.Log("zort");
        StartCoroutine(LoadSceneAfterDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        Debug.Log("logged");
        gameManegar.realeseSlow();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
