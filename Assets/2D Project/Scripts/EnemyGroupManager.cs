using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{
    public float speed = 5f;
    public float speedMultiplier = 1.2f;
    bool triggeredThisStep = false; //Prevents rows from moving down multiple times per frame
    public AudioClip enemyDestroyed;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnEnemyReachedEdge += OnEnemyReachedEdge;
        Enemy.OnEnemyDied += OnEnemyDied;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        triggeredThisStep = false;
        Vector3 newPosition = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
        transform.position = newPosition;
    }

    void OnEnemyReachedEdge(float rowHeight)
    {
        if (triggeredThisStep)
        {
            return;
        }
        triggeredThisStep = true;
        speed = -speed;
        transform.position = transform.position - new Vector3(0, rowHeight, 0);
    }

    void OnEnemyDied(float score)
    {
        speed = speed * speedMultiplier;
        audioSource.PlayOneShot(enemyDestroyed);
    }
}
