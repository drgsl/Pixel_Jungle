using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class pongSideWall : MonoBehaviour
{
    pongBall pongBall;

    public string pongBallTag = "Pong/Ball";
    public string pongScoreTag = "Pong/Score/Right";

    public static int ScoreLeft = 0;
    public static int ScoreRight = 0;

    private TMP_Text ScoreText;

    private void Awake()
    {
        pongBall = GameObject.FindGameObjectWithTag(pongBallTag).GetComponent<pongBall>();
        ScoreLeft = 0;
        ScoreRight = 0;
        ScoreText = GameObject.FindGameObjectWithTag(pongScoreTag).GetComponent<TMP_Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(pongBallTag))
        {
            pongBall.restartBall();

            if (pongScoreTag.EndsWith("Right"))
            {
                ScoreRight++;
                ScoreText.text = ScoreRight.ToString();
            }
            else if (pongScoreTag.EndsWith("Left"))
            {
                ScoreLeft++;
                ScoreText.text = ScoreLeft.ToString();
            }
            if(ScoreLeft == 5 || ScoreRight == 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
