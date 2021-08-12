using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Config Params
    public float moveSpeed = 20f;
    public float speedModifier = 0.2f;
    Touch touch;
    float dirX;

    // Cached References
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveByGyro();
        MoveByTouch();
    }

    private void MoveByTouch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
    }

    private void MoveByGyro()
    {
        dirX = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.6f, 2.6f), transform.position.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, 0f);
    }
}
