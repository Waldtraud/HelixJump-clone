using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    /* public Rigidbody rb;
     /* [SerializeField] private float _radiusOfExplosion;
      [SerializeField] private float _powerOfExplosion;
     public PlatformDestruction _destruction;*/
    [SerializeField] private float _fallSpeed;
    [SerializeField] private float _angleOfRotation;
    public Transform[] sectors;
    [SerializeField] private Vector3 CenterOfMovement;


    /*private void Start()   
    {
        sectors =  new Transform[transform.childCount];
        int i = 0;
        foreach (Transform sector in sectors)
        {
            i++;
        }
        Debug.Log("Count: " + i);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            player.CurrentPlatform = this;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.transform.position.y < transform.position.y)
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



