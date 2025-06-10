using System.Collections;
using UnityEngine;

public class TrackerAI : MonoBehaviour
{
    public float attackModeRadius = 5f; // Distance from player where boss stays in Attack Mode
    public float aggressiveModeRadius = 7f; // Distance where boss switches to Aggressive Mode

    public float fireModeDuration = 10f; // Duration boss stays in Fire Mode
    public float dashModeDuration = 10f; // Duration boss stays in Dash Mode

    private Transform player;
    private BossPhaseController bossPhaseController;
    private DashToPlayer dashToPlayer;

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


        bossPhaseController = GetComponent<BossPhaseController>();
        dashToPlayer = GetComponent<DashToPlayer>();

        if (bossPhaseController == null)
            Debug.LogError("BossPhaseController script is missing!");
        if (dashToPlayer == null)
            Debug.LogError("DashToPlayer script is missing!");


        
    }

    private void Update()
    {
        if (player == null || bossPhaseController == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > aggressiveModeRadius)
        {

            bossPhaseController.SetPhase(BossPhaseController.BossPhase.Aggressive);
            isChoosingPhase = false; // Stop mode selection
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
            int randomMode = Random.Range(0, 2); // 0 = FireMode, 1 = DashMode

            if (randomMode == 0)
            {
                bossPhaseController.SetPhase(BossPhaseController.BossPhase.FireMode);
                yield return new WaitForSeconds(fireModeDuration);
            }
            else
            {
                bossPhaseController.SetPhase(BossPhaseController.BossPhase.Dash);
                yield return new WaitForSeconds(dashModeDuration);
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
