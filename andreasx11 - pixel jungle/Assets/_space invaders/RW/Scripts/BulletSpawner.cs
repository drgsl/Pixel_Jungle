using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    internal int currentRow;
    internal int column;

    [SerializeField]
    private AudioClip shooting;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float minTime;

    [SerializeField]
    private float maxTime;

    private float timer;
    private float currentTime;
    private Transform followTarget;

    internal void Setup()
    {
        currentTime = Random.Range(minTime, maxTime);
        followTarget = InvaderSwarm.Instance.GetInvader(currentRow, column);
    }

    private void Update()
    {
        transform.position = followTarget.position;

        timer += Time.deltaTime;
        if (timer < currentTime)
        {
            return;
        }

        Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        GameManager.Instance.PlaySfx(shooting);
        timer = 0f;
        currentTime = Random.Range(minTime, maxTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.GetComponent<Bullet>())
        {
            return;
        }

        GameManager.Instance.
            UpdateScore(InvaderSwarm.Instance.GetPoints(followTarget.gameObject.name));

        InvaderSwarm.Instance.IncreaseDeathCount();

        followTarget.GetComponentInChildren<SpriteRenderer>().enabled = false;
        currentRow = currentRow - 1;
        if (currentRow < 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Setup();
        }
    }
}