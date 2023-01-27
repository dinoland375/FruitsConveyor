using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    [SerializeField] private List<GameObject> fruits;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float startTimeSpawns;
    
    private float _timeSpawns;
    
    private void Start()
    {
        _timeSpawns = startTimeSpawns;
    }

    private void Update()
    {
        if (_timeSpawns <= 0)
        {
            var rand = Random.Range(0, fruits.Count);
            Instantiate(fruits[rand], spawnPoint);
            _timeSpawns = startTimeSpawns;
        }
        else
        {
            _timeSpawns -= Time.deltaTime;
        }
    }
}
