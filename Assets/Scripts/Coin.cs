using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Config Params
    public int coinScore = 10;
    [SerializeField] float speed = 5f;
    Score score;

    // Cached References
    Collider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<Collider2D>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinMovingDown();
    }

    private void CoinMovingDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isTouchingPlayer = circleCollider.IsTouchingLayers(LayerMask.GetMask("Player"));

        if (isTouchingPlayer)
        {
            score.AddToScore(coinScore);
        }

        Destroy(gameObject);
    }
}
