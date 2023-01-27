using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button exitTheGame = null;
    [SerializeField] private Button playGameBoy = null;
    [SerializeField] private Button playGameGirl = null;
    [SerializeField] private GameObject changeGender;
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        playButton.onClick.AddListener(ChangeGender);
        exitTheGame.onClick.AddListener(ExitTheGame);
        playGameBoy.onClick.AddListener(PlayGameBoy);
        playGameGirl.onClick.AddListener(PlayGameGirl);
    }

    private void ChangeGender()
    {
        audioSource.PlayOneShot(audioClip);
        changeGender.SetActive(true);
    }

    private void PlayGameBoy()
    {
        audioSource.PlayOneShot(audioClip);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Gender", 0);
        sceneTransition.SwitchToScene("Game");
    }
    
    private void PlayGameGirl()
    {
        audioSource.PlayOneShot(audioClip);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Gender", 1);
        sceneTransition.SwitchToScene("Game");
    }

    private void ExitTheGame()
    {
        audioSource.PlayOneShot(audioClip);
        Application.Quit();
    }
}
