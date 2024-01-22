using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject baseWindow;

    [Header("Window Content")]
    [SerializeField] private GameObject creditsContent;
    [SerializeField] private GameObject leaderboardContent;
    [SerializeField] private GameObject playContent;
    [SerializeField] private GameObject quitContent;
    [SerializeField] private GameObject settingsContent;


    public void Close()
    {
        baseWindow.SetActive(false);
    }

    public void CreditsWindow()
    {
        baseWindow.SetActive(true);
        creditsContent.SetActive(true);
        leaderboardContent.SetActive(false);
        playContent.SetActive(false);
        quitContent.SetActive(false);
        settingsContent.SetActive(false);
    }

    public void LeaderboardWindow()
    {
        baseWindow.SetActive(true);
        creditsContent.SetActive(false);
        leaderboardContent.SetActive(true);
        playContent.SetActive(false);
        quitContent.SetActive(false);
        settingsContent.SetActive(false);
    }

    public void PlayWindow()
    {
        baseWindow.SetActive(true);
        creditsContent.SetActive(false);
        leaderboardContent.SetActive(false);
        playContent.SetActive(true);
        quitContent.SetActive(false);
        settingsContent.SetActive(false);
    }

    public void QuitWindow()
    {
        baseWindow.SetActive(true);
        creditsContent.SetActive(false);
        leaderboardContent.SetActive(false);
        playContent.SetActive(false);
        quitContent.SetActive(true);
        settingsContent.SetActive(false);
    }

    public void SettingsWindow()
    {
        baseWindow.SetActive(true);
        creditsContent.SetActive(false);
        leaderboardContent.SetActive(false);
        playContent.SetActive(false);
        quitContent.SetActive(false);
        settingsContent.SetActive(true);
    }
}
