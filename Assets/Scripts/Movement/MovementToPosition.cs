using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MovementEvents))]
[DisallowMultipleComponent]
public class MovementToPosition : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private MovementEvents movementEvents;

    private void Awake()
    {
        // Load Components
        rigidBody2D = GetComponent<Rigidbody2D>();
        movementEvents = GetComponent<MovementEvents>();
    }

    private void OnEnable()
    {
        // Subscribe to movement to position event
        movementEvents.OnMovementToPosition += HandleOnMovementToPosition;
    }

    private void OnDisable()
    {
        // Unsubscribe from movement to position event
        movementEvents.OnMovementToPosition -= HandleOnMovementToPosition;
    }

    // On movement event
    private void HandleOnMovementToPosition(MovementEvents movementToPositionEvent, MovementToPositionArgs movementToPositionArgs)
    {
        MoveRigidBody(movementToPositionArgs.movePosition, movementToPositionArgs.currentPosition, movementToPositionArgs.moveSpeed);
    }

    /// <summary>
    /// Move the rigidbody component
    /// </summary>
    private void MoveRigidBody(Vector3 movePosition, Vector3 currentPosition, float moveSpeed)
    {
        Vector2 unitVector = Vector3.Normalize(movePosition - currentPosition);

        rigidBody2D.MovePosition(rigidBody2D.position + (unitVector * moveSpeed * Time.fixedDeltaTime));
    }
}