using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player 1");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player 1'.");
        }

      
    }

    void Update()
    {
        if (player == null) return;

        // Check if the player is to the right (+X) or left (-X)
        /*
        if ((player.position.x > transform.position.x && transform.localScale.x < 0) ||
            (player.position.x < transform.position.x && transform.localScale.x > 0))
        {
            // Multiply X scale by -1 to flip horizontally
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        */
        if (player == null) return;


        if ((player.position.x > transform.position.x && Mathf.Round(transform.localRotation.eulerAngles.y) == 180) ||
            (player.position.x < transform.position.x && Mathf.Round(transform.localRotation.eulerAngles.y) == 0))
        {

            transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y == 0 ? 180 : 0, 0);
        }

    }
}
