using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Cached References
    [SerializeField] GameObject coinPrefab;

    // Variables related to spawning
    float timebtwSpawn;
    [SerializeField] float startTimeBtwSpawn = 0.4f;
    Vector3 randomPos;
    [SerializeField] float minX = -2.6f;
    [SerializeField] float maxX = 2.6f;

    // Update is called once per frame
    void Update()
    {
        Spawning();
    }

    private void Spawning()
    {
        if (timebtwSpawn <= 0)
        {
            randomPos = new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
            Instantiate(coinPrefab, randomPos, Quaternion.identity);
            timebtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timebtwSpawn -= Time.deltaTime;
        }
    }
}
