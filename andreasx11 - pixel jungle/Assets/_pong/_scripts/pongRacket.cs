using System.Collections;
using UnityEngine;

public class pongRacket : MonoBehaviour
{
    public float speed = 30;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;


    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float yDir = 0;

        if (Input.GetKey(moveUp))
        {
            yDir = 1;
        }
        else if (Input.GetKey(moveDown))
        {
            yDir = -1;
        }

        rb.velocity = new Vector2(0, yDir) * speed;
    }

}