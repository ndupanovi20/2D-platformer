using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Oznacavamo da je igrac pokupio kljuc
            GameManager.instance.hasKey = true;
            // Uništavamo kljuè sa scene
            Destroy(gameObject);
        }
    }
}
