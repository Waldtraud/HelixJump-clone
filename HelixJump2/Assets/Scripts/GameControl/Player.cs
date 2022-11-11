using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _bounceSpeed;
    public Rigidbody _playerBody;
    public Game _game;
    public Platform CurrentPlatform;

    private void Start()
    {
        EventManager.OnPlayerReachFinish.AddListener(ReachFinish);
        EventManager.OnPlayerDied.AddListener(Die);
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
   
}
