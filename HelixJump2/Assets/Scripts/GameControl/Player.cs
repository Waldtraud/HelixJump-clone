using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private AudioSource _bounceSound;
    private float currentContactPoint;
    private float lastContactPoint;

    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private float _bounceSpeed;
    [SerializeField] private float _numberOfPassedPlatform;
    [SerializeField] private Rigidbody _playerBody;

    [SerializeField] public Game Game;
    [SerializeField] public Platform CurrentPlatform;


    private void Start()
    {
        _bounceSound = GetComponent<AudioSource>();
        EventManager.OnPlayerReachFinish.AddListener(ReachFinish);
        EventManager.OnPlayerDied.AddListener(Die);
        EventManager.OnAddPlatformBroke.RemoveListener(Die);

    }

    private void OnCollisionStay(Collision collision)
    {
         AddBounceSound();

    }

    private void OnCollisionEnter(Collision collision)
    {       
        currentContactPoint = collision.transform.position.y/3;

        float distanceToPass = Mathf.Abs(currentContactPoint - lastContactPoint);
        
        if (distanceToPass > _levelGenerator._distanceBetweenPlatforms * _numberOfPassedPlatform)
        {  
                    
            distanceToPass = 0;
            CurrentPlatform.FallDown();
            EventManager.SentAddPlatformBroke();
        }

        lastContactPoint = currentContactPoint;        
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
