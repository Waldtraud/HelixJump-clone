using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _fallSpeed;
    [SerializeField] public int _platformToPass;
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player) && other.transform.position.y < transform.position.y)
        {
            EventManager.SentBrokenPlatforms();
            FallDown();
            Destroy(this.gameObject, 0.3f);
        }
    }

    


    public void FallDown()
    {
        Rigidbody[] sectors = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < sectors.Length; i++)

            if (sectors[i] != null)
            {
                sectors[i].isKinematic = false;
                sectors[i].AddForce(0, 0, _fallSpeed);
            }
               }

  /*  private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Vector3 normal = collision.contacts[0].normal.normalized;
            if (!_collider.bounds.Contains(normal))
                _platformToPass--;
        }


    }*/

}



