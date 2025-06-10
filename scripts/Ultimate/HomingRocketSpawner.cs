using System.Collections;
using UnityEngine;

public class HomingRocketSpawner : MonoBehaviour
{
    public GameObject homingRocketPrefab; // the homing rocket prefab in the Inspector
    public Transform firePoint; // fire point (empty GameObject) for rocket spawn location
    public float fireRate = 2f; // Time between each burst
    public int rocketsPerBurst = 3; // Number of rockets per burst

    private Coroutine firingCoroutine;

    void OnEnable()
    {

        firingCoroutine = StartCoroutine(FireRockets());
    }

    void OnDisable()
    {

        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireRockets()
    {
        while (true)
        {
            for (int i = 0; i < rocketsPerBurst; i++)
            {
                GameObject bulletInstance = Instantiate(homingRocketPrefab, firePoint.position, firePoint.rotation);
                ShooterTag bulletScript = bulletInstance.GetComponent<ShooterTag>();

                if (bulletScript != null)
                {


                    bulletScript.SetShooterTag(transform.parent.tag); 
                                                                      // Debug.Log("transform.parent.tag: " + transform.parent.tag);
                }
                else
                {
                    Debug.Log("bulletScript == null");
                }
                yield return new WaitForSeconds(0.2f); 
            }

            yield return new WaitForSeconds(fireRate); 
        }
    }
}
