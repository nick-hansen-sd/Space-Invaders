using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;

    void Start()
    {
        // todo - get and cache animator
    }
    
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");
            Destroy(shot, 3f);
            GetComponent<Animator>().SetTrigger("Shot Trigger");
        }
    }
}
