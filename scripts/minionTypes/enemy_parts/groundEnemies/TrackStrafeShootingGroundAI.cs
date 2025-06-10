using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackStrafeShootingGroundAI : MonoBehaviour
{
    public float attackModeRadius = 5f; // Distance from player where boss stays in Attack Mode
    public float aggressiveModeRadius = 7f; // Distance where boss switches to Aggressive Mode

    public float fireModeDuration = 10f; // Duration boss stays in Fire Mode
    public float dashModeDuration = 10f; // Duration boss stays in Dash Mode

    private Transform player;
    private GroundEnemyPhaseController groundPhaseController;
    private bool isChoosingPhase = false;

    private void Start()
    {

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player 1");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player 1' not found!");
        }

        groundPhaseController = GetComponent<GroundEnemyPhaseController>();

        if (groundPhaseController == null)
        {
            Debug.LogError("GroundEnemyPhaseController script is missing!");
        }
    }

    private void Update()
    {
        if (player == null || groundPhaseController == null) return;


        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > aggressiveModeRadius)
        {

            groundPhaseController.SetPhase(GroundEnemyPhaseController.GroundEnemyPhase.TrackerMode);
            isChoosingPhase = false; 
        }
        else if (distanceToPlayer < attackModeRadius)
        {

            if (!isChoosingPhase)
            {
                isChoosingPhase = true;
                StartCoroutine(ChooseAttackMode());
            }
        }
    }

    IEnumerator ChooseAttackMode()
    {
        while (isChoosingPhase)
        {
            int randomMode = Random.Range(0, 1); 


            if (randomMode == 0)
            {
                groundPhaseController.SetPhase(GroundEnemyPhaseController.GroundEnemyPhase.StrafeFireFacePlayerMode);
                yield return new WaitForSeconds(fireModeDuration);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackModeRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, aggressiveModeRadius);
    }
}
