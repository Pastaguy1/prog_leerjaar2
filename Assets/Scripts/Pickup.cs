using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public static event Action OnPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickedUp?.Invoke(); // Stuur event
            Destroy(gameObject);  // Verwijder de pickup
        }
    }
}
