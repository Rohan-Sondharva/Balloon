using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    // Config Params
    [SerializeField] float speed = 5f;

    // Cached References
    Collider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<Collider2D>();
    }

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
        bool isTouchingPlayer = boxCollider.IsTouchingLayers(LayerMask.GetMask("Player"));

        if (isTouchingPlayer)
        {
            SceneManager.LoadScene("Game Over");
            Destroy(gameObject);
        }
    }
}
