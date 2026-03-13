using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    
    public AudioClip ticClip;
    public AudioClip tacClip;

    public delegate void EnemyDiedFunc(float points);
    public static event EnemyDiedFunc OnEnemyDied;

    public delegate void EnemyReachedEdgeFunc(float height);
    public static event EnemyDiedFunc OnEnemyReachedEdge;
    float rowHeight = 1.4f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // todo - destroy the bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            if (CompareTag("Enemy1"))
            {
                OnEnemyDied.Invoke(30);
            } else if (CompareTag("Enemy2"))
            {
                OnEnemyDied.Invoke(20);
            } else if (CompareTag("Enemy3"))
            {
                OnEnemyDied.Invoke(10);
            }
        }
        // todo - trigger death animation
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Edge"))
        {
            Debug.Log("Enemy entered edge");
            OnEnemyReachedEdge.Invoke(rowHeight);
        } else if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Credits");
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
