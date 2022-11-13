using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class LevelGenerator : MonoBehaviour
{
    [SerializeField] public Game Game;

    [SerializeField] public GameObject[] _platformsPrefabs;
    [SerializeField] public GameObject _firstPlatform;
    [SerializeField] public int _maxPlatforms;
    [SerializeField] public int _minPlatforms;
    [SerializeField] public float _distanceBetweenPlatforms;
    [SerializeField] public Transform _finishPlatform;
    [SerializeField] public Transform _cylinderLength;
    

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);
        int platformsCount = RandomRange(random, _minPlatforms, _maxPlatforms + 1);

        for (var i = 0; i < platformsCount; i++)
        {
            var prefabIndex = RandomRange(random, 0, _platformsPrefabs.Length);
            GameObject platformPrefab = i == 0 ? _firstPlatform : _platformsPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);

            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }
        _finishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
        _cylinderLength.localScale = new Vector3(1, platformsCount * _distanceBetweenPlatforms, 1);
    }

    private int RandomRange(Random random, int min, int max)
    {
        int number = random.Next();
        int lenght = max - min;
        number %= lenght;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 CalculatePlatformPosition(int platfornIndex)
    {
        return new Vector3(0, -_distanceBetweenPlatforms * platfornIndex, 0);
    }
}
