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
        // Zavr�avamo igru
        Debug.Log("Game Over! You win!");
        // Ovde mo�ete dodati logiku za zavr�avanje igre
    }
}
