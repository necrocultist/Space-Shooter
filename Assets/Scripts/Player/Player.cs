using System;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(MovementByVelocity))]
[RequireComponent(typeof(MovementEvents))]
[RequireComponent(typeof(Idle))]
[RequireComponent(typeof(TeleportNegativeY))]
[RequireComponent(typeof(ActiveWeapon))]
[RequireComponent(typeof(FireWeapon))]
[RequireComponent(typeof(WeaponEvents))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthEvents))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerDetailsSO playerDetails;
    [HideInInspector] public MovementEvents movementEvents;
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public ActiveWeapon activeWeapon;
    [HideInInspector] public WeaponEvents weaponEvents;
    [HideInInspector] public Health health;
    [HideInInspector] public HealthEvents healthEvent;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;


    private void Awake()
    {
        playerDetails = GetComponent<PlayerDetailsSO>();
        playerControl = GetComponent<PlayerControl>();
        activeWeapon = GetComponent<ActiveWeapon>();
        weaponEvents = GetComponent<WeaponEvents>();
        movementEvents = GetComponent<MovementEvents>();
        animator = GetComponent<Animator>();
    }

    public void Initialize(PlayerDetailsSO playerDetails)
    {
        this.playerDetails = playerDetails;

        SetPlayerHealth();
    }

    private void SetPlayerHealth()
    {
        throw new NotImplementedException();
    }
}