using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] public Player Player;
    [SerializeField] public Transform FinishPlatform;
    [SerializeField] public Slider Slider;
    [SerializeField] public float AccptebleFinishDistance;

    private float _startPosition;
    private float _minReachedY;

    public void Start()
    {
        _startPosition = Player.transform.position.y;
    }

    public void Update()
    {
        _minReachedY = Mathf.Min(_minReachedY, Player.transform.position.y);
        float finishPosition = FinishPlatform.transform.position.y;
        float result = Mathf.InverseLerp(_startPosition, finishPosition + AccptebleFinishDistance, _minReachedY);
        Slider.value = result;
    }
}
