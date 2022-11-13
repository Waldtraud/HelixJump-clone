using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventManager 
{
    public static UnityEvent OnBrokenPlatformCount = new UnityEvent();
    public static UnityEvent OnPlayerDied = new UnityEvent();
    public static UnityEvent OnPlayerReachFinish = new UnityEvent();

    public static void SentBrokenPlatforms()
    {
        OnBrokenPlatformCount.Invoke();
    }

    public static void SentPlayerDied()
    {
        OnPlayerDied.Invoke();
    }

    public static void SentPlayerReachFinish()
    {
        OnPlayerReachFinish.Invoke();
    }
}
