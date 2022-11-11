using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : Screen
{
 
    [SerializeField] private GameObject _button;
    
    [SerializeField] private GameObject _image;

    private void Start()
    {
        EventManager.OnPlayerReachFinish.AddListener(ShowScreen);
    }
    public override void ShowScreen()
    {
     
        _button.SetActive(true);
      
        _image.SetActive(true);
    }

    public override void HideScreen()
    {
    
        _button.SetActive(false);
      
        _image.SetActive(false);
    }

}
