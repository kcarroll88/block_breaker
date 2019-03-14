using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // Config
    [SerializeField] Paddle paddle1;
    [SerializeField] float xSpeed = 100f;
    [SerializeField] float ySpeed = 350f;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }

    }

    private void LockBallToPaddle()
    {
        if (hasStarted == false)
        {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
            hasStarted = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (hasStarted == true)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
