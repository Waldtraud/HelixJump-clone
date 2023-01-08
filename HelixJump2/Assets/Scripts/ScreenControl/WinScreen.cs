using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : Screen
{
 
    [SerializeField] private GameObject _button;    
    

    private void Start()
    {
        EventManager.OnPlayerReachFinish.AddListener(ShowScreen);
    }
    public override void ShowScreen()
    {     
        _button.SetActive(true);      
       
    }

    public override void HideScreen()
    {    
        _button.SetActive(false);      
       
    }

}
