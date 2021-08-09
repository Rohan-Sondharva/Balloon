using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    // Config Params
    [SerializeField] float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        ObstacleMovingDown();
    }

    private void ObstacleMovingDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
        Destroy(gameObject);
    }
}
