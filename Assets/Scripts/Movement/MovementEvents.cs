using System;
using UnityEngine;

[DisallowMultipleComponent]
public class MovementEvents : MonoBehaviour
{
    public event Action<MovementEvents, MovementByVelocityEventArgs> OnMovementByVelocity;
    public event Action<MovementEvents, MovementToPositionArgs> OnMovementToPosition;
    public event Action<MovementEvents> OnIdle;
    public event Action<MovementEvents> OnTeleport;

    public void CallMovementByVelocityEvent(Vector2 moveDirection, float moveSpeed)
    {
        OnMovementByVelocity?.Invoke(this,
            new MovementByVelocityEventArgs() { moveDirection = moveDirection, moveSpeed = moveSpeed });
    }

    public void CallMovementToPositionEvent(Vector3 movePosition, Vector3 currentPosition, float moveSpeed,
        Vector2 moveDirection)
    {
        OnMovementToPosition?.Invoke(this,
            new MovementToPositionArgs()
            {
                movePosition = movePosition, currentPosition = currentPosition, moveSpeed = moveSpeed,
                moveDirection = moveDirection
            });
    }

    public void CallIdleEvent()
    {
        OnIdle?.Invoke(this);
    }

    public void CallTeleportEvent()
    {
        OnTeleport?.Invoke(this);
    }
}

public class MovementByVelocityEventArgs : EventArgs
{
    public Vector2 moveDirection;
    public float moveSpeed;
}

public class MovementToPositionArgs : EventArgs
{
    public Vector3 movePosition;
    public Vector3 currentPosition;
    public float moveSpeed;
    public Vector2 moveDirection;
}