using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private AudioSource _bounceSound;
    [SerializeField] public Game Game;
    [SerializeField] public Platform CurrentPlatform;


    [SerializeField] private float _bounceSpeed;
    [SerializeField] private Rigidbody _playerBody;
    [SerializeField] private int _platformToPass;



    private void Start()
    {
        _bounceSound = GetComponent<AudioSource>();
        EventManager.OnPlayerReachFinish.AddListener(ReachFinish);
        EventManager.OnPlayerDied.AddListener(Die);
    }

    private void OnCollisionStay(Collision collision)
    {
        AddBounceSound();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Sector sector) && _platformToPass <0)
            _platformToPass--;

        CurrentPlatform.FallDown();
    }

    public void Bounce()
    {
        _playerBody.velocity = new Vector3(0, _bounceSpeed, 0);
    }
    public void Die()
    {
        _playerBody.velocity = Vector3.zero;

    }
    public void ReachFinish()
    {
        _playerBody.velocity = Vector3.zero;
    }

    public void AddBounceSound()
    {
        _bounceSound.Play();
    }

    

}
