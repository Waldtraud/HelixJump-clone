using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private bool _isGood;
    [SerializeField] private Material _goodMaterial;
    [SerializeField] private Material _badMaterial;
    [SerializeField] private float movementSpeed;
    public Rigidbody _rigidbody;
    [SerializeField] private float _radiusOfExplosion;


    private void Awake()
    {
        UpdateMaterials();
    }

    private void Start()
    {
       _rigidbody.isKinematic = true;

        //EventManager.OnBrokenPlatformCount.AddListener(FallDown);
    }

    /*public void FallDown()
    {
        foreach (Transform child in transform)
        {

            child.position += Vector3.left * movementSpeed;
        }
        /*Collider[] colliders = Physics.OverlapSphere(this.transform.position, _radiusOfExplosion);
        foreach (Collider collider in colliders)
            collider.attachedRigidbody.isKinematic = false;
            //collider.attachedRigidbody.AddForce(0,1,0);
        //if (this._rigidbody.isKinematic == true)
        

        //rb.isKinematic = false;
        ////transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, -movementSpeed * Time.deltaTime, 0);
    }*/
    private void UpdateMaterials()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = _isGood ? _goodMaterial : _badMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player))
            return;
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);

        if (dot < 0.5f) return;

        if (!_isGood)
            EventManager.SentPlayerDied();
        else
            player.Bounce();
    }

    private void OnValidate()
    {
        UpdateMaterials();
    }
}
