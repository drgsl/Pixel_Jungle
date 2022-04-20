using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    internal static GameManager Instance;

    [SerializeField]
    private AudioSource sfx;
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float explosionTime = 1f;

    [SerializeField]
    private AudioClip explosionClip;

    [SerializeField]
    private int maxLives = 3;

    [SerializeField]
    private Text livesLabel;

    private int lives;

    [SerializeField]
    private MusicControl music;

    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject allClear;

    [SerializeField]
    private Button restartButton;

    private int score;

    internal void UpdateScore(int value)
    {
        score += value;
        scoreLabel.text = $"Score: {score}";
    }

    internal void TriggerGameOver(bool failure = true)
    {
        gameOver.SetActive(failure);
        allClear.SetActive(!failure);
        restartButton.gameObject.SetActive(true);

        Time.timeScale = 0f;
        music.StopPlaying();
    }


    internal void UpdateLives()
    {
        lives = Mathf.Clamp(lives - 1, 0, maxLives);
        livesLabel.text = $"Lives: {lives}";
        if (lives > 0)
        {
            return;
        }

        TriggerGameOver();
    }
    internal void CreateExplosion(Vector2 position)
    {
        PlaySfx(explosionClip);

        var explosion = Instantiate(explosionPrefab, position,
            Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f)));
        Destroy(explosion, explosionTime);
    }

    internal void PlaySfx(AudioClip clip) => sfx.PlayOneShot(clip);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        lives = maxLives;
        livesLabel.text = $"Lives: {lives}";


        score = 0;
        scoreLabel.text = $"Score: {score}";
        gameOver.gameObject.SetActive(false);
        allClear.gameObject.SetActive(false);

        restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        });
        restartButton.gameObject.SetActive(false);
    }
}