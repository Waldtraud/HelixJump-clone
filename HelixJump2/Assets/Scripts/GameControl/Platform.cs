using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{  
    [SerializeField] private float _fallSpeed;
 
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
            Destroy(this.gameObject, 0.5f);
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
}



