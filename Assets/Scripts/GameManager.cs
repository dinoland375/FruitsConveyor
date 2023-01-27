using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gender;

    public GameObject scoreImage;
    public List<Sprite> spritesScore;
    public TextMeshProUGUI countFruitsText;
    public int countFruits;

    private void Awake()
    {
        gender[PlayerPrefs.GetInt("Gender")].SetActive(true);
    }

    private void Start()
    {
        var rand = Random.Range(0, spritesScore.Count);
        countFruits = Random.Range(3, 7);
        scoreImage.GetComponent<Image>().sprite = spritesScore[rand];
        countFruitsText.text = "" + countFruits.ToString();
    }
}
