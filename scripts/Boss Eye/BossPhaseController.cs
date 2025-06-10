using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseController : MonoBehaviour
{
    private FollowPlayer followPlayer;
    private BossRotation bossRotation;
    private MoveToPlayerY moveToPlayerY;
    private DashToPlayer dashToPlayer;
    private ErraticMovement erraticMovement;
    private FireMode fireMode; 
    private IdleMode idleMode;

    public enum BossPhase
    {
        Idle,              // Boss does nothing
        FollowY,          // Boss follows the player
        RotateOnly,       // Boss rotates to face the player
        Aggressive,       // Boss both rotates and follows aggressively
        Dash,             // Boss performs a dash towards the player
        ErraticMovement,  // Boss moves erratically
        FireMode          // Boss fires projectiles at the player
    }

    public BossPhase currentPhase = BossPhase.Idle;
    public float aggressiveSpeedMultiplier = 2f; 

    void Start()
    {

        followPlayer = GetComponent<FollowPlayer>();
        bossRotation = GetComponent<BossRotation>();
        moveToPlayerY = GetComponent<MoveToPlayerY>();
        dashToPlayer = GetComponent<DashToPlayer>();
        erraticMovement = GetComponent<ErraticMovement>();
        fireMode = GetComponent<FireMode>(); 
        idleMode = GetComponent<IdleMode>();


        if (followPlayer == null) Debug.LogError("FollowPlayer script is missing from the boss!");
        if (bossRotation == null) Debug.LogError("BossRotation script is missing from the boss!");
        if (moveToPlayerY == null) Debug.LogError("MoveToPlayerY script is missing from the boss!");
        if (dashToPlayer == null) Debug.LogError("DashToPlayer script is missing from the boss!");
        if (fireMode == null) Debug.LogError("FireMode script is missing from the boss!");
        if (idleMode == null) Debug.LogError("idleMode script is missing from the boss!");
    }

    void Update()
    {

        switch (currentPhase)
        {
            case BossPhase.Idle:
                HandleIdlePhase();
                break;
            case BossPhase.FollowY:
                HandleFollowPlayerYPhase();
                break;
            case BossPhase.RotateOnly:
                HandleRotateOnlyPhase();
                break;
            case BossPhase.Aggressive:
                HandleAggressivePhase();
                break;
            case BossPhase.Dash:
                HandleDashPhase();
                break;
            case BossPhase.ErraticMovement:
                HandleErraticMovementPhase();
                break;
            case BossPhase.FireMode:
                HandleFireModePhase();
                break;
        }
    }

    

    // Idle phase logic
    void HandleIdlePhase()
    {
        if (idleMode != null) idleMode.enabled = true;
        if (followPlayer != null) followPlayer.enabled = false;
        if (bossRotation != null) bossRotation.enabled = false;
        if (moveToPlayerY != null) moveToPlayerY.enabled = false;
        if (dashToPlayer != null) dashToPlayer.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (fireMode != null)
        {
            fireMode.enabled = false;  
        }
    }

    // Follow Y-axis phase logic
    void HandleFollowPlayerYPhase()
    {
        if (idleMode != null) idleMode.enabled = false;
        if (followPlayer != null) followPlayer.enabled = false;
        if (bossRotation != null) bossRotation.enabled = true;
        if (moveToPlayerY != null) moveToPlayerY.enabled = true;
        if (dashToPlayer != null) dashToPlayer.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (fireMode != null)
        {
            fireMode.enabled = false;  
        }
    }

    void HandleRotateOnlyPhase()
    {
        if (idleMode != null) idleMode.enabled = false;
        if (followPlayer != null) followPlayer.enabled = false;
        if (bossRotation != null) bossRotation.enabled = true;
        if (moveToPlayerY != null) moveToPlayerY.enabled = false;
        if (dashToPlayer != null) dashToPlayer.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (fireMode != null)
        {
            fireMode.enabled = false;  
        }
    }


    void HandleAggressivePhase()
    {
        if (idleMode != null) idleMode.enabled = false;
        if (followPlayer != null)
        {
            followPlayer.enabled = true;
            followPlayer.speed = 3f * aggressiveSpeedMultiplier; 
        }
        if (bossRotation != null) bossRotation.enabled = true;
        if (moveToPlayerY != null) moveToPlayerY.enabled = false;
        if (dashToPlayer != null) dashToPlayer.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (fireMode != null)
        {
            fireMode.enabled = false;  
        }
    }

    // Dash phase logic
    void HandleDashPhase()
    {
        if (idleMode != null) idleMode.enabled = false;
        if (followPlayer != null) followPlayer.enabled = false;
        if (bossRotation != null) bossRotation.enabled = false;
        if (moveToPlayerY != null) moveToPlayerY.enabled = false;
        if (dashToPlayer != null) dashToPlayer.enabled = true;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (fireMode != null)
        {
            fireMode.enabled = false; 
        }
    }

    // Erratic Movement phase logic
    void HandleErraticMovementPhase()
    {
        if (idleMode != null) idleMode.enabled = false;
        if (followPlayer != null) followPlayer.enabled = false;
        if (bossRotation != null) bossRotation.enabled = true;
        if (moveToPlayerY != null) moveToPlayerY.enabled = false;
        if (dashToPlayer != null) dashToPlayer.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = true;
        if (fireMode != null)
        {
            fireMode.enabled = false;  
        }
    }
    // FireMode phase logic
    void HandleFireModePhase()
    {
        if (idleMode != null) idleMode.enabled = false;
        if (followPlayer != null) followPlayer.enabled = false;
        if (bossRotation != null) bossRotation.enabled = true;
        if (moveToPlayerY != null) moveToPlayerY.enabled = false;
        if (dashToPlayer != null) dashToPlayer.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = true;

        if (fireMode != null)
        {
            fireMode.enabled = true;  
        }
    }
    // Public method to set the boss phase
    public void SetPhase(BossPhase phase)
    {
        currentPhase = phase;
    }
}
