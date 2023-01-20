using UnityEngine;

[DisallowMultipleComponent]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private MovementDetailsSO movementDetails;
    [SerializeField] private AimDirection aimDirection;
    private Player player;
    private float moveSpeed;
    private bool isPlayerMovementDisabled = false;
    private bool buttonDownPreviousFrame = false;

    private void Awake()
    {
        player = GetComponent<Player>();
        moveSpeed = movementDetails.GetMoveSpeed();
    }

    private void Start()
    {
        SetAnimationSpeed();
        // SetStartingWeapon();
    }

    private void Update()
    {
        if (isPlayerMovementDisabled) return;

        MovementInput();

        WeaponInput();

        TeleportInput();
    }

    private void MovementInput()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement).normalized;

        if (direction != Vector2.zero)
        {
            player.movementEvents.CallMovementByVelocityEvent(direction, moveSpeed);
        }
        else
        {
            player.movementEvents.CallIdleEvent();
        }
    }

    private void WeaponInput()
    {
        Vector3 weaponDirection;
        switch (aimDirection)
        {
            case AimDirection.Up:
                weaponDirection = Vector3.left;
                break;
            case AimDirection.Down:
                weaponDirection = Vector3.right;
                break;
            case AimDirection.Right:
                weaponDirection = Vector3.up;
                break;
            case AimDirection.Left:
                weaponDirection = Vector3.down;
                break;
            default:
                weaponDirection = Vector3.up;
                break;
        }

        FireWeaponInput(weaponDirection);
    }

    private void FireWeaponInput(Vector3 weaponDirection)
    {
        if (Input.GetButton("Fire1"))
        {
            player.weaponEvents.CallFireWeaponEvent(true, weaponDirection, buttonDownPreviousFrame);
            buttonDownPreviousFrame = true;
        }
        else
        {
            buttonDownPreviousFrame = false;
        }
    }

    private void TeleportInput()
    {
        if (Input.GetKeyDown(Settings.playerTeleportButton))
        {
            player.movementEvents.CallTeleportEvent();
        }
    }

    private void ReloadWeaponInput()
    {
        // Weapon currentWeapon = player.activeWeapon.GetCurrentWeapon();
    }

    /// Set player animator speed to match movement speed
    private void SetAnimationSpeed()
    {
        player.animator.speed = Settings.baseSpeedForPlayerAnimations;
    }

    public void EnablePlayerMovement()
    {
        isPlayerMovementDisabled = false;
    }

    #region Validation

#if UNITY_EDITOR

    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(movementDetails), movementDetails);
    }

#endif

    #endregion Validation
}