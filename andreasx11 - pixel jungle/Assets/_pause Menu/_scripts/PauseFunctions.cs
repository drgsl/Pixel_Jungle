using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public static KeyCode PauseMenuKey = KeyCode.Escape;
    protected bool Paused = false;

    public Transform pauseCanvas;

    [Range(1.0f, 99f)]
    public float gameSlowFactor = 50f;
    private void Start()
    {
        if (!pauseCanvas)
        {
            pauseCanvas = transform.GetChild(0);
        }
        unPause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(PauseMenuKey))
        {
            if (isPaused())
            {
                unPause();
            }
            else
            {
                Pause();
            }
        }
    }

    protected bool isPaused()
    {
        return Paused;
    }

    protected void Pause()
    {
        Time.timeScale = 1f / gameSlowFactor;
        pauseCanvas.gameObject.SetActive(true);
        Paused = true;
    }
    protected void unPause()
    {
        Time.timeScale = 1f;

        pauseCanvas.gameObject.SetActive(false);
        Paused = false;
    }


}
