using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] public Controls Control;
    /*[SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private int _platformToPass;*/
    public State CurrentState { get; private set; }
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    private const string LevelIndexKey = "LevelIndex";

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
    }

    public void OnPlayerRechFinish()
    {
        if (CurrentState != State.Playing)
            return;

        CurrentState = State.Won;
        Control.enabled = false;

        LevelIndex++;
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

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   /* public void DestroyFourthPlatform()
    {
        GameObject[] platforms = _levelGenerator.GetPlatformsList();
        int numberToDestroy;

        for (var i = 0; i < platforms.Length; i++)
        {

            numberToDestroy = i + _platformToPass + 1;
            Platform platformToDestroy = platforms[numberToDestroy].GetComponent<Platform>();

            platformToDestroy.FallDown();
            i = numberToDestroy;
        }
    }*/


}
