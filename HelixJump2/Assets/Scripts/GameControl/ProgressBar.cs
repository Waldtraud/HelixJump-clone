using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] public Player _player;
    [SerializeField] public Transform _finishPlatform;
    [SerializeField] public Slider _slider;
    [SerializeField] public float _accptebleFinishDistance;

    private float _startPosition;
    private float _minReachedY;

    public void Start()
    {
        _startPosition = _player.transform.position.y;
    }

    public void Update()
    {
        _minReachedY = Mathf.Min(_minReachedY, _player.transform.position.y);
        float finishPosition = _finishPlatform.transform.position.y;
        float result = Mathf.InverseLerp(_startPosition, finishPosition + _accptebleFinishDistance, _minReachedY);
        _slider.value = result;
    }
}
