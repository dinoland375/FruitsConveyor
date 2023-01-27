using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
    [SerializeField] private Transform contentContainer;
    [SerializeField] private Transform parentBasket;
    [SerializeField] private Transform basket;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject player;
    [SerializeField] private string finalDance;
    [SerializeField] private AudioClip finalMusic;

    public GameObject fruit = null;

    private void Start()
    {
        if (GameObject.Find("Player").activeInHierarchy)
        {
            player = GameObject.Find("Player");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.scoreImage.GetComponent<Image>().sprite == gameManager.spritesScore[0] && other.gameObject.CompareTag("Apple") || 
            gameManager.scoreImage.GetComponent<Image>().sprite == gameManager.spritesScore[1] && other.gameObject.CompareTag("Banana") ||
            gameManager.scoreImage.GetComponent<Image>().sprite == gameManager.spritesScore[2] && other.gameObject.CompareTag("Watermelon"))
        {
            gameManager.countFruits--;
            gameManager.countFruitsText.text = "" + gameManager.countFruits;
            Instantiate(scoreText, contentContainer);
            fruit.transform.SetParent(parentBasket);
            fruit.transform.position = basket.position;
            fruit.GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void Update()
    {
        if (gameManager.countFruits <= 0)
        {
            GameObject.Find("Main Camera").GetComponent<CameraFollower>().finish = true;
            player.GetComponent<Animator>().SetBool(finalDance, true);
            player.GetComponent<AudioSource>().PlayOneShot(finalMusic);
        }
    }
}
