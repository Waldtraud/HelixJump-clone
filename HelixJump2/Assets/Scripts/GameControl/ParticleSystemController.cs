using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private GameObject _finish;
    [SerializeField] private ParticleSystem _lossSystem;   
    [SerializeField] private Player _player;
    

    private void Start()
    {
        EventManager.OnPlayerReachFinish.AddListener(WinParticleSystem);
        EventManager.OnPlayerDied.AddListener(DiedParticleSystem);
       
       EventManager.OnBrokenPlatform.AddListener(BreakPlatformParticleSystem);
    }

    public void WinParticleSystem()
    {

        _finish.GetComponent<ParticleSystem>().Play();

    }

    public void DiedParticleSystem()
    {
        _lossSystem.Play();

    }

    public void BreakPlatformParticleSystem()
    {
        _player.CurrentPlatform.GetComponent<ParticleSystem>().Play();        
    }
}
