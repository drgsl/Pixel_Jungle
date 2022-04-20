using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq; // because of the list

[RequireComponent(typeof(SpriteRenderer))]
public class Snake_Head : MonoBehaviour
{
    [Tooltip("measured in seconds")]
    public float moveDelay = 0.3f;

    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 dir = Vector2.right;

    // Keep Track of Tail
    List<Transform> tail = new List<Transform>();

    // Did the snake eat something?
    bool ate = false;

    // Tail Prefab
    public GameObject tailPrefab;

    private SpriteRenderer spriteRenderer;


    private static int score = 0;
    private TMP_Text scoreText;

    private void Awake()
    {
        score = 0;
        scoreText = GameObject.FindGameObjectWithTag("Snake/Score").GetComponent<TMP_Text>();
    }

    // Use this for initialization
    void Start()
    {
        // Move the Snake every 300ms
        InvokeRepeating("Move", moveDelay, moveDelay);
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per Frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        //special cases
        if ((horiz == 0 && vert == 0) || (horiz == 1 && vert == 1))
        {
            return;
        }
        dir = new Vector2(horiz, vert);
        
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spriteRenderer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        //// Move in a new Direction?
        //if (Input.GetKey(KeyCode.RightArrow))
        //    dir = Vector2.right;
        //else if (Input.GetKey(KeyCode.DownArrow))
        //    dir = -Vector2.up;    // '-up' means 'down'
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //    dir = -Vector2.right; // '-right' means 'left'
        //else if (Input.GetKey(KeyCode.UpArrow))
        //    dir = Vector2.up;
    }

    void Move()
    {
        // Save current position (gap will be here)
        Vector2 currPosition = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);

        // Ate something? Then insert new Element into gap
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab,
                                                  currPosition,
                                                  Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = currPosition;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Snake/Food"))
        {
            ate = true;

            score++;
            scoreText.text = score.ToString();

            Snake_SpawnFood.spawn1FoodPiece();
            
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
