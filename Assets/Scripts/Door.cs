using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openDoor;  

    void Start()
    {
       
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    void Update()
    {
        if (GameManager.instance.hasKey)
        {
            
            closedDoor.SetActive(false);
          
            openDoor.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance.hasKey)
        {
            
            GameManager.instance.EndGame();
        }
    }
}
