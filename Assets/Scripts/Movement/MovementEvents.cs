using System;
using UnityEngine;

[DisallowMultipleComponent]
public class MovementEvents : MonoBehaviour
{
    public event Action<MovementEvents, MovementByVelocityEventArgs> OnMovementByVelocity;
    public event Action <MovementEvents> OnIdle;
    public event Action <MovementEvents> OnTeleport;

    public void CallMovementByVelocityEvent(Vector2 moveDirection, float moveSpeed)
    {
        OnMovementByVelocity?.Invoke(this,
            new MovementByVelocityEventArgs() { moveDirection = moveDirection, moveSpeed = moveSpeed });
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
