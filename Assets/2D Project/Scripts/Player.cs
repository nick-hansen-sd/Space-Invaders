using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public float speed = 10f;
    float minX = -7.4f;
    float maxX = 7.4f;
    public AudioClip shoot;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // todo - get and cache animator
    }
    
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            audioSource.PlayOneShot(shoot);
            Debug.Log("Bang!");
            Destroy(shot, 3f);
            GetComponent<Animator>().SetTrigger("Shot Trigger");
        }

        if (Keyboard.current.aKey.isPressed)
        {
            Vector3 newPosition = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            Vector3 newPosition = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }
    }
}
