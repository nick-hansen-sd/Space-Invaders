using UnityEngine;

public class IndependentEnemy : MonoBehaviour
{
    public delegate void IndependentEnemyDiedFunc(float points);
    public static event IndependentEnemyDiedFunc OnIndependentEnemyDied;
    
    public float speed = 5f;
    public AudioClip enemyDestroyed;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
        transform.position = newPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        
        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            audioSource.PlayOneShot(enemyDestroyed);
            Destroy(collision.gameObject);
            Destroy(gameObject);

            int random = Random.Range(0, 5);
            int[] possibilities = {50, 100, 150, 200, 300};  //Possible random point values
            OnIndependentEnemyDied(possibilities[random]);        
        }
    }
}
