using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool hasKey = false;

    void Awake()
    {
        // Osiguravamo da postoji samo jedan GameManager instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        // Završavamo igru
        Debug.Log("Game Over! You win!");
        // Ovde možete dodati logiku za završavanje igre
    }
}
