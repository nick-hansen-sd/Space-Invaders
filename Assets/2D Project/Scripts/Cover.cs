using UnityEngine;

public class Cover : MonoBehaviour
{
    public float health = 5f;
    Transform sparks;

    void Start()
    {
        sparks = transform.Find("Sparks");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            health -= 1;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            } else if (health <= 2)
            {
                sparks.gameObject.SetActive(true);
            }
        }
    }
}
