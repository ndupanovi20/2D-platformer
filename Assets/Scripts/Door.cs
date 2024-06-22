using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject closedDoor; // Reference na zatvorena vrata
    public GameObject openDoor;   // Reference na otvorena vrata

    void Start()
    {
        // Inicijalno postavljamo da su vrata zatvorena
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    void Update()
    {
        if (GameManager.instance.hasKey)
        {
            // Ako igraè ima kljuè, otvaramo vrata
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance.hasKey)
        {
            // Ako igraè ima kljuè i prolazi kroz vrata, završavamo igru
            GameManager.instance.EndGame();
        }
    }
}
