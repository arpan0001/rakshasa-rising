using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    // Assuming the Player class is in the same namespace as PlayerSensor
    // If not, replace YourNamespace with the correct namespace.

    // Define the Player class (or use your existing Player class definition)
    public class Player : MonoBehaviour
    {
        // Your Player class implementation
    }

    public delegate void PlayerEnterEvent(Transform player);
    public delegate void PlayerExitEvent(Vector3 lastKnownPosition);
    public event PlayerEnterEvent OnPlayerEnter;
    public event PlayerExitEvent OnPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the Player component
        if (other.TryGetComponent(out Player player))
        {
            // Invoke the event with the player's transform
            OnPlayerEnter?.Invoke(player.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object has the Player component
        if (other.TryGetComponent(out Player player))
        {
            // Invoke the event with the last known position of the player
            OnPlayerExit?.Invoke(player.transform.position);
        }
    }
}
