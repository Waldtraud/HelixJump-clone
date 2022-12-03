using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private AudioSource _brokenPlatformSound;
    [SerializeField] private float _fallSpeed;
    [SerializeField] public int _platformToPass;


    private void Start()
    {
        _brokenPlatformSound = GetComponent<AudioSource>();
    }

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
        {

            if (sectors[i] != null)
            {
                sectors[i].isKinematic = false;
                sectors[i].AddForce(0, 0, _fallSpeed);
            }
        }
        AddBrokenPlatformSound();
    }

    public void AddBrokenPlatformSound()
    {
        _brokenPlatformSound.Play();
    }
}



