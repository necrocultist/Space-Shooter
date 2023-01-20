using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MovementEvents))]
[DisallowMultipleComponent]
public class MovementByVelocity : MonoBehaviour
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
        movementEvents.OnMovementByVelocity += HandleOnOnMovementByVelocityEvent;
    }

    private void OnDisable()
    {
        movementEvents.OnMovementByVelocity += HandleOnOnMovementByVelocityEvent;
    }

    private void HandleOnOnMovementByVelocityEvent(MovementEvents movementEvents, MovementByVelocityEventArgs movementByVelocityEventArgs)
    {
        MoveRigidBody(movementByVelocityEventArgs.moveDirection, movementByVelocityEventArgs.moveSpeed);
    }

    private void MoveRigidBody(Vector2 moveDirection, float moveSpeed)
    {
        rigidbody2D.velocity = moveDirection * moveSpeed;
    }
}