using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Config Params
    [SerializeField] float speed = 5f;

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
        Destroy(gameObject);
    }
}
