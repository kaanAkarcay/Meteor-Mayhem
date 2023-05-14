using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private static MusicManager instance; // Singleton instance

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

        // Check if an instance already exists
        if (instance == null)
        {
            instance = this; // Set the instance to this object
        }
        else
        {
            Destroy(gameObject); // Destroy the duplicate instance
        }
    }

    public static MusicManager GetInstance()
    {
        return instance;
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
