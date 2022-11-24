using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private bool _isGood;
    [SerializeField] private Material _goodMaterial;
    [SerializeField] private Material _badMaterial;    
    public Rigidbody _rigidbody;



    private void Awake()
    {
        UpdateMaterials();
    }

    private void Start()
    {
       _rigidbody.isKinematic = true;        
    }
   
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
