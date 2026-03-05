using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnEnemyReachedEdge += OnEnemyReachedEdge;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
        transform.position = newPosition;
    }

    void OnEnemyReachedEdge(float rowHeight)
    {
        speed = -speed;
        transform.position = transform.position - new Vector3(0, rowHeight, 0);
    }
}
