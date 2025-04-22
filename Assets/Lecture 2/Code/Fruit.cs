using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private bool destroyOnTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fruit eaten");
        if (destroyOnTrigger)
        {
            Destroy(gameObject);
        }
    }
}
