using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Transform destination;
    public string nextRoomName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destination.position;
            Debug.Log("Entered " + nextRoomName);
        }
    }
}
