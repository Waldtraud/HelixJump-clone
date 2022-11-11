using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private Screen _activScreen;
    private List<Screen> _screens;   


    private void Start()
    {
        _screens = new List<Screen>();
        _screens.AddRange(GetComponentsInChildren<Screen>());

        foreach (var screen in _screens)
        {
            if (screen is StartScreen)
            {
                screen.ShowScreen();
                _activScreen = screen;
            }
            else
            {
                screen.HideScreen();
            }
        }
    }

    public void StartGame()
    {
        _activScreen.HideScreen();

        foreach (var screen in _screens)
        {
            if (screen is GameScreen)
            {
                screen.ShowScreen();
                _activScreen = screen;
                break;
            }
        }
    }

    public void WinGame()
    {
        _activScreen.HideScreen();

        foreach (var screen in _screens)
        {
            if (screen is WinScreen)
            {
                screen.ShowScreen();
                _activScreen = screen;
                break;
            }
        }
    }

    public void LoseGame()
    {
        _activScreen.HideScreen();

        foreach (var screen in _screens)
        {
            if (screen is LoseScreen)
            {
                screen.ShowScreen();
                _activScreen = screen;
                break;
            }
        }
    }


}
