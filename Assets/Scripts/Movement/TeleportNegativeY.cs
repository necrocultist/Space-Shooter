using UnityEngine;

[DisallowMultipleComponent]
public class TeleportNegativeY : MonoBehaviour
{
    private MovementEvents movementEvents;
    
    private void Awake()
    {
        movementEvents = GetComponent<MovementEvents>();
    }

    private void OnEnable()
    {
        movementEvents.OnTeleport += HandleTeleportEvent;
    }

    private void OnDisable()
    {
        movementEvents.OnTeleport -= HandleTeleportEvent;
    }
    
    private void HandleTeleportEvent(MovementEvents movementEvents)
    {
        TeleportPlayer();
    }
    
    private void TeleportPlayer()
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y * -1, position.z);
        transform.position = position;
    }
}
