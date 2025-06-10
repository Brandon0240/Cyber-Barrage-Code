using UnityEngine;

public class FlipToMouse : MonoBehaviour
{
  
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
    
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

 
        if (mousePosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
