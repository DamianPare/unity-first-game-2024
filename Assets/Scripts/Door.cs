using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public float openDistance = 2f;
    public float closeDelay = 5f;

    private Vector3 initialPosition;
    private bool isOpen = false;

    void Start()
    {
        initialPosition = door.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            Vector3 newPosition = initialPosition + Vector3.up * openDistance;
            door.position = newPosition;
            Invoke("CloseDoor", closeDelay);
        }
    }

    void CloseDoor()
    {
        if (isOpen)
        {
            isOpen = false;
            door.position = initialPosition;
        }
    }
}
