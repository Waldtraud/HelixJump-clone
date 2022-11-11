using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{
    /*[SerializeField] private float _radiusOfExplosion;
    [SerializeField] private float _powerOfExplosion;
    

    private void Start()
    {
        EventManager.OnBrokenPlatformCount.AddListener(FallDown);
    }
    public void FallDown()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, _radiusOfExplosion);
        
        foreach (Collider sector in colliders)
        {
            Rigidbody rb = sector.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(_powerOfExplosion, explosionPos, _radiusOfExplosion, 3.0F);
                Debug.Log("Booh, Booh!!!");
            }
            
        }
    }*/
}
