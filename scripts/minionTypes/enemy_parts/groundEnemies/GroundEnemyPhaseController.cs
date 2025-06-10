using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyPhaseController : MonoBehaviour
{
    private GroundBasicEnemyMovement groundBasicMovement;
    private ErraticGroundMovement erraticMovement;
    private FireMode weaponFire;
    private FacePlayer facePlayer;

    public enum GroundEnemyPhase
    {
        TrackerMode,    // Follows the player
        GroundStrafe,   // Moves erratically on the ground
        WeaponFireMode, // Fires weapons at the player
        FacePlayerMode,  // Rotates to face the player
        StrafeFireFacePlayerMode // Rotates to facefireface the player
    }

    public GroundEnemyPhase currentPhase = GroundEnemyPhase.TrackerMode;

    void Start()
    {

        groundBasicMovement = GetComponent<GroundBasicEnemyMovement>();
        erraticMovement = GetComponent<ErraticGroundMovement>();
        weaponFire = GetComponent<FireMode>();
        facePlayer = GetComponent<FacePlayer>();


        if (groundBasicMovement == null) Debug.LogError("GroundBasicEnemyMovement script is missing!");
        if (erraticMovement == null) Debug.LogError("ErraticGroundMovement script is missing!");
        if (weaponFire == null) Debug.LogError("GroundEnemyWeaponFire script is missing!");
        if (facePlayer == null) Debug.LogError("FacePlayer script is missing!");
        
            if (groundBasicMovement != null) groundBasicMovement.enabled = false;
            if (erraticMovement != null) erraticMovement.enabled = false;
            if (weaponFire != null) weaponFire.enabled = false;
            if (facePlayer != null) facePlayer.enabled = false;
        
    }

    void Update()
    {
        switch (currentPhase)
        {
            case GroundEnemyPhase.TrackerMode:
                HandleTrackerMode();
                break;
            case GroundEnemyPhase.GroundStrafe:
                HandleGroundStrafeMode();
                break;
            case GroundEnemyPhase.WeaponFireMode:
                HandleWeaponFireMode();
                break;
            case GroundEnemyPhase.FacePlayerMode:
                HandleFacePlayerMode();
                break;
            case GroundEnemyPhase.StrafeFireFacePlayerMode:
                StrafeFireFacePlayerMode();
                break;
        }
    }

    // Tracker mode - follows the player
    void HandleTrackerMode()
    {
        if (groundBasicMovement != null) groundBasicMovement.enabled = true;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (weaponFire != null) weaponFire.enabled = false;
        if (facePlayer != null) facePlayer.enabled = false;
    }

    // Ground strafe mode - erratic movement on ground
    void HandleGroundStrafeMode()
    {
        if (groundBasicMovement != null) groundBasicMovement.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = true;
        if (weaponFire != null) weaponFire.enabled = false;
        if (facePlayer != null) facePlayer.enabled = true;
    }

    // Weapon fire mode - enemy stops and fires at the player
    void HandleWeaponFireMode()
    {
        if (groundBasicMovement != null) groundBasicMovement.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (weaponFire != null) weaponFire.enabled = true;
        if (facePlayer != null) facePlayer.enabled = false;
    }

    // Face player mode - enemy stops and turns toward the player
    void HandleFacePlayerMode()
    {
        if (groundBasicMovement != null) groundBasicMovement.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = false;
        if (weaponFire != null) weaponFire.enabled = false;
        if (facePlayer != null) facePlayer.enabled = true;
    }
    // strafefireface player mode -
    void StrafeFireFacePlayerMode()
    {
        if (groundBasicMovement != null) groundBasicMovement.enabled = false;
        if (erraticMovement != null) erraticMovement.enabled = true;
        if (weaponFire != null) weaponFire.enabled = true;
        if (facePlayer != null) facePlayer.enabled = true;
    }

    public void SetPhase(GroundEnemyPhase phase)
    {
        currentPhase = phase;
    }
}
