using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private Button back = null;
    [SerializeField] private Button restart = null;
    [SerializeField] private Button exit = null;
    [SerializeField] private Button pause = null;
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        back.onClick.AddListener(Back);
        restart.onClick.AddListener(Restart);
        exit.onClick.AddListener(Exit);
        pause.onClick.AddListener(PauseMenu);
    }

    private void Back()
    {
        audioSource.PlayOneShot(audioClip);
        pauseMenu.SetActive(false);
    }

    private void Restart()
    {
        audioSource.PlayOneShot(audioClip);
        sceneTransition.SwitchToScene("Game");
    }

    private void Exit()
    {
        audioSource.PlayOneShot(audioClip);
        sceneTransition.SwitchToScene("Menu");
    }

    private void PauseMenu()
    {
        audioSource.PlayOneShot(audioClip);
        pauseMenu.SetActive(true);
    }
}
