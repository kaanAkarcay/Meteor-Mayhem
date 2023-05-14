using UnityEngine;
using UnityEngine.UI;

public class MusicControlButton : MonoBehaviour
{
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = MusicManager.GetInstance();
    }

    public void OnClickPlayButton()
    {
        musicManager.PlayMusic();
    }

    public void OnClickPauseButton()
    {
        musicManager.PauseMusic();
    }

    public void OnClickStopButton()
    {
        musicManager.StopMusic();
    }
}