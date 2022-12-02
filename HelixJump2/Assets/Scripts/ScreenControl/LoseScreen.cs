using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseScreen : Screen
{
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _button;
    [SerializeField] private Player player;

    private void Start()
    {
      EventManager.OnPlayerDied.AddListener(ShowScreen);
        
    }
    public override void ShowScreen()
    {
        _slider.SetActive(true);
        _button.SetActive(true);
    }

    public override void HideScreen()
    {
        _slider.SetActive(false);
        _button.SetActive(false);
    }
}
