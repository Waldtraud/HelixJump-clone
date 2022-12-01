using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Screen
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

   /*private void ShowLevelIndex()
    {
        int levelIndex = Game.LevelIndex;
    }*/

}
