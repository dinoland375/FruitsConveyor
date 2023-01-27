using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 distanceFromObject;
    [SerializeField] private GameObject contentContainer;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject conveyor;
    [SerializeField] private GameObject basketContainer;
    [SerializeField] private GameObject finishMenu;
    [SerializeField] private Button restart = null;
    [SerializeField] private Button exit = null;
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    public bool finish;

    private void Start()
    {
        if (GameObject.Find("Player").activeInHierarchy)
        {
            player = GameObject.Find("Player");
        }
        restart.onClick.AddListener(Restart);
        exit.onClick.AddListener(Exit);
    }

    private void LateUpdate()
    {
        if (finish)
        {
            Vector3 positionToGo = player.transform.position + distanceFromObject;
            Vector3 smoothPosition = Vector3.Lerp(a:transform.position, b:positionToGo, t:0.0125F);
            transform.position = smoothPosition;
            transform.LookAt(player.transform.position);
            spawnPoint.SetActive(false);
            contentContainer.SetActive(false);
            basketContainer.SetActive(false);
            conveyor.SetActive(false);
            finishMenu.SetActive(true);
        }
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
}
