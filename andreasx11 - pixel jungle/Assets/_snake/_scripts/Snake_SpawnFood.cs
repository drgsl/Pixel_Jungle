using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_SpawnFood : MonoBehaviour
{
    //singleton
    public static Snake_SpawnFood instance;
    
    // Food Prefab
    public GameObject foodPrefab;

    // Borders
    public static Transform borderTop;
    public static Transform borderBottom;
    public static Transform borderLeft;
    public static Transform borderRight;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }


        borderTop = GameObject.FindGameObjectWithTag("Snake/Borders/Top").transform;
        borderBottom = GameObject.FindGameObjectWithTag("Snake/Borders/Bottom").transform;
        borderLeft = GameObject.FindGameObjectWithTag("Snake/Borders/Left").transform;
        borderRight = GameObject.FindGameObjectWithTag("Snake/Borders/Right").transform;
    }

    void Start()
    {
        spawn1FoodPiece();
    }

    public static void spawn1FoodPiece()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(instance.foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
