using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrokenPlatformsCount : MonoBehaviour
{
    private int _platformCount = 0;   

    private void Start()
    {
        EventManager.OnBrokenPlatformCount.AddListener(CountPlatforms);
    }

    public void CountPlatforms()
    {
        _platformCount++;
        GetComponent<TMP_Text>().text = _platformCount.ToString();
    }
}
