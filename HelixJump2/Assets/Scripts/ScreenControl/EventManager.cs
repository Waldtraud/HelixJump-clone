using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventManager 
{
    public static UnityEvent OnBrokenPlatform = new UnityEvent();
    public static UnityEvent OnPlayerDied = new UnityEvent();
    public static UnityEvent OnPlayerReachFinish = new UnityEvent();
    public static UnityEvent OnAddPlatformBroke = new UnityEvent();

    public static void SentBrokenPlatforms()
    {
        OnBrokenPlatform.Invoke();
    }

    public static void SentPlayerDied()
    {
        OnPlayerDied.Invoke();
    }

    public static void SentPlayerReachFinish()
    {
        OnPlayerReachFinish.Invoke();
    }

    public static void SentAddPlatformBroke()
    {
        OnAddPlatformBroke.Invoke();
    }


}
