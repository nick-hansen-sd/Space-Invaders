using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public AudioClip ticClip;
    public AudioClip tacClip;

    public delegate void EnemyDiedFunc(float points);
    public static event EnemyDiedFunc OnEnemyDied;

    public delegate void EnemyReachedEdgeFunc(float num);
    public static event EnemyDiedFunc OnEnemyReachedEdge;

    public float speed = 5f;
    float minX = -7.4f;
    float maxX = 7.4f;
    float rowHeight = 1.4f;

    void Update()
    {
        // Vector3 newPosition = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
        // transform.position = newPosition;
        // if (transform.position.x <= minX || transform.position.x >= maxX)
        // {
        //     speed = -speed;
        //     transform.position = transform.position - new Vector3(0, rowHeight, 0);
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        
        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            OnEnemyDied.Invoke(10);
        }
        // todo - trigger death animation
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Edge"))
        {
            Debug.Log("Enemy entered edge");
            OnEnemyReachedEdge.Invoke(rowHeight);
        }
    }

    public void PlayTicSound()
    {
        GetComponent<AudioSource>().PlayOneShot(ticClip);
    }

    public void PlayTacSound()
    {
        GetComponent<AudioSource>().PlayOneShot(tacClip);
    }
}
