using UnityEngine;

public class Fruit2 : MonoBehaviour
{
    [SerializeField] private bool checkPlayer = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (checkPlayer && !other.gameObject.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Fruit eaten");
        Destroy(gameObject);
    }
}
