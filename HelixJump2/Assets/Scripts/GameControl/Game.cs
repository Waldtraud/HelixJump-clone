using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Control;

    public State CurrentState { get; private set; }
    public enum State
    {
        Playing,
        Won,
        Loss
    }
    private void Start()
    {
        EventManager.OnPlayerReachFinish.AddListener(OnPlayerRechFinish);
        EventManager.OnPlayerDied.AddListener(OnPlayingDied);
    }


    public void OnPlayingDied()
    {
        if (CurrentState != State.Playing)
            return;

        CurrentState = State.Loss;
        Control.enabled = false;
        Debug.Log("Game Over");       
    }

   /* public void DestroyPlatform(Platform platform)
    {
        Destroy(platform);
    }*/

    public void OnPlayerRechFinish()
    {
        if (CurrentState != State.Playing)
            return;

        CurrentState = State.Won;
        Control.enabled = false;
       LevelIndex++;
        Debug.Log("You Won");       
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
