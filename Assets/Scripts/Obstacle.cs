using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    // Config Params
    [SerializeField] float speed;
    [SerializeField] float minSpeed = 3f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float secToMaxSpeed = 60f;
    public bool isAlive = true;

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
        IncreasingSpeedOvertime();
    }

    void IncreasingSpeedOvertime()
    {
        // Increase the speed to max speed in 60 seconds
        speed = Mathf.Lerp(minSpeed, maxSpeed, GetSpeedPercent());
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
            isAlive = false;
            SceneManager.LoadScene("Game Over");
            Destroy(gameObject);
        }
    }

    float GetSpeedPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secToMaxSpeed);
    }
}
