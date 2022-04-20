using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongBall : MonoBehaviour
{
    Rigidbody2D rb;


    public float startSpeed = 40;
    public float speedFactor = 2f;
    
    [SerializeField]private float speed;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        resetSpeed();
        Invoke("GoBall", 2);
    }
    public void restartBall()
    {
        resetBallPosition();
        resetSpeed();
        Invoke("GoBall", 1);
    }
    private void resetSpeed()
    {
        speed = startSpeed;
    }

    void GoBall()
    {
        rb.AddForce(new Vector2(plusMinus1() * startSpeed, plusMinus1() * startSpeed));
    }

    void resetBallPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    float plusMinus1()
    {
        int value = Random.Range(0, 2);

        if (value == 1)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Hit the left Racket?
        if (collision.gameObject.CompareTag("Pong/Racket/Left"))
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed *= speedFactor;
        }

        // Hit the right Racket?
        if (collision.gameObject.CompareTag("Pong/Racket/Right"))
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed *= speedFactor;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

}
