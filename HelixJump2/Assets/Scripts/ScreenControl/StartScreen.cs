using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : Screen
{   
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _touchPanel;
    [SerializeField] private GameObject _button;

    public override void ShowScreen()
    {
        _text.SetActive(true);
        _touchPanel.SetActive(true);
        _button.SetActive(true);
    }

    public override void HideScreen()
    {
        _text.SetActive(false);
        _touchPanel.SetActive(false);
        _button.SetActive(false);
    }

}
