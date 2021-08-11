using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Cached References
    [SerializeField] GameObject obstaclePrefab;

    // Variables related to spawning
    float timebtwSpawn;
    [SerializeField] float startTimeBtwSpawn = 3f;
    Vector3 randomPos;
    [SerializeField] float minX = -1.89f;
    [SerializeField] float maxX = 1.89f;

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
            Instantiate(obstaclePrefab, randomPos, Quaternion.identity);
            timebtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timebtwSpawn -= Time.deltaTime;
        }
    }
}
