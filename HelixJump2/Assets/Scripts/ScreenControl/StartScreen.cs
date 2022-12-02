using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : Screen
{
    [SerializeField] public Game Game;

   [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _levelCurrentNumber;
    [SerializeField] private GameObject _levelNextNumber;

    public override void ShowScreen()
    {
       _slider.SetActive(true);
        _levelCurrentNumber.SetActive(true);
        _levelNextNumber.SetActive(true);
    }

    public override void HideScreen()
    {
        _slider.SetActive(false);
        _levelCurrentNumber.SetActive(false);
        _levelNextNumber.SetActive(false);
    }
}
