using System.Collections;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public Transform gunTransform; 
    public float recoilAmount = 0.1f;
    public float recoilDuration = 0.05f;

    public void ApplyRecoil()
    {
        StartCoroutine(RecoilEffect());
    }

    private IEnumerator RecoilEffect()
    {
        Vector3 originalPosition = gunTransform.localPosition;
        Vector3 recoilOffset = new Vector3(Random.Range(-recoilAmount, recoilAmount), Random.Range(-recoilAmount, recoilAmount), 0);

        gunTransform.localPosition += recoilOffset;
        yield return new WaitForSeconds(recoilDuration);
        gunTransform.localPosition = originalPosition;
    }
}
