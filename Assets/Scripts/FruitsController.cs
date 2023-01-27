using System;
using UnityEngine;
using UnityEngine.UI;

public class FruitsController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private string takeFruitAnim;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform parent;
    [SerializeField] private AudioClip[] soundEffects;
    
    private AudioSource audio;
    private Camera cam;
    private Plane[] planes;
    private Collider objCollider;
    private BasketController basketController;
    private GameManager gameManager;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        objCollider = GetComponent<Collider>();
        player = GameObject.Find("Player");
        parent = GameObject.Find("ParentFruit").transform;
        basketController = GameObject.Find("Basket").GetComponent<BasketController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update () 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (!GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.scoreImage.GetComponent<Image>().sprite == gameManager.spritesScore[0] && gameObject.CompareTag("Apple") ||
            gameManager.scoreImage.GetComponent<Image>().sprite == gameManager.spritesScore[1] && gameObject.CompareTag("Banana") ||
            gameManager.scoreImage.GetComponent<Image>().sprite == gameManager.spritesScore[2] && gameObject.CompareTag("Watermelon"))
        {
            audio.PlayOneShot(soundEffects[0]);
            TakeFruit();
        }
        else
        {
            audio.PlayOneShot(soundEffects[1]);
            Handheld.Vibrate();
        }
    }

    private void OnMouseUp()
    {
        player.GetComponent<Animator>().SetBool(takeFruitAnim, false);
    }

    private void TakeFruit()
    {
        basketController.fruit = this.gameObject;
        speed = 0f;
        player.GetComponent<Animator>().SetBool(takeFruitAnim, true);
        transform.SetParent(parent, true);
        transform.position = parent.position;
    }
}
