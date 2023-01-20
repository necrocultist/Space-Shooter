using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MovementEvents))]
public class Idle : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private MovementEvents movementEvents;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        movementEvents = GetComponent<MovementEvents>();
    }

    private void OnEnable()
    {
        movementEvents.OnIdle += HandleIdleEvent;
    }

    private void OnDisable()
    {
        movementEvents.OnIdle -= HandleIdleEvent;
    }

    private void HandleIdleEvent(MovementEvents movementEvents)
    {
        MoveRigidbody();
    }

    private void MoveRigidbody()
    {
        // ensure the rb collision detection is set to continuous
        rigidbody2D.velocity = Vector2.zero;
    }
}
