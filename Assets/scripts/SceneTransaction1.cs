using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransaction1: MonoBehaviour
{
    [SerializeField] string sceneName;

    [SerializeField] float delay;
   
   
    public void LoadSceneWithDelay()
    {
        Debug.Log("zort");
        StartCoroutine(LoadSceneAfterDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        Debug.Log("logged");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
