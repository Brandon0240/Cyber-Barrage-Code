using UnityEngine;

public class GroundEnemyTrigger : MonoBehaviour
{
    public float detectionRadiusX = 5f; // Horizontal detection radius (width)
    public float detectionRadiusY = 2f; // Vertical detection radius (height)
    public Vector2 detectionOffset = new Vector2(0f, 0f); // Offset to apply to the detection box position

    private Transform player;


    private float damageCooldown = 1f; // Time between damage applications
    private float damageTimer = 1f; // Timer to keep track of cooldown
    public int damageAmount = 10; // Amount of damage dealt to the player

    private KnockBackOnPlayer knockbackScript;
    private DamageOnPlayer damagingScript;
    void Start()
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
        EnemyStatSheet statSheet = FindObjectOfType<EnemyStatSheet>();
        if (statSheet != null)
        {

            EnemyStats basicEnemyStats = statSheet.GetEnemyStats("BasicEnemy");


            damageAmount = basicEnemyStats.damage;
        }
        else
        {
            Debug.LogError("EnemyStatSheet not found in the scene!");
        }
        knockbackScript = GetComponent<KnockBackOnPlayer>();
        damagingScript = GetComponent<DamageOnPlayer>();



    }
    
    void Update()

    {
        damageTimer += Time.deltaTime;


        if (IsPlayerInDetectionRadius())
        {


            if (damageTimer >= damageCooldown)
            {
                if(knockbackScript != null)
                {
                    knockbackScript.ApplyKnockBack();
                }
                if (damagingScript != null)
                {
                    damagingScript.ApplyDamageToPlayer();
                }
              
                damageTimer = 0f; 
            }
    
        }
        
    }
    private void ApplyDamageToPlayer()
    {
  
        GameObject player = GameObject.FindGameObjectWithTag("Player 1");

        if (player != null)
        {
            HealthManagerPlayer healthManager = player.GetComponent<HealthManagerPlayer>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damageAmount);
            }
        }
    }
    // Checks if the player is within the detection radius defined by the rectangle
    bool IsPlayerInDetectionRadius()
    {
      
        Vector2 topLeft = (Vector2)transform.position + detectionOffset + new Vector2(-detectionRadiusX / 2, detectionRadiusY / 2);
        Vector2 bottomRight = (Vector2)transform.position + detectionOffset + new Vector2(detectionRadiusX / 2, -detectionRadiusY / 2);


        if (player != null)
        {
            float playerX = player.position.x;
            float playerY = player.position.y;

            return playerX >= topLeft.x && playerX <= bottomRight.x && playerY <= topLeft.y && playerY >= bottomRight.y;
        }

        return false;
    }

    // Draw a rectangular area in the scene view to represent the detection radius
    private void OnDrawGizmosSelected()
    {
  
        Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
    
        Vector2 topLeft = (Vector2)transform.position + detectionOffset + new Vector2(-detectionRadiusX / 2, detectionRadiusY / 2);
        Vector2 bottomRight = (Vector2)transform.position + detectionOffset + new Vector2(detectionRadiusX / 2, -detectionRadiusY / 2);

        Gizmos.DrawWireCube((topLeft + bottomRight) / 2, new Vector3(detectionRadiusX, detectionRadiusY, 0f));
    }
}
