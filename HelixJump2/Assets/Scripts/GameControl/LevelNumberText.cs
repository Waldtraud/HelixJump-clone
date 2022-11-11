using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNumberText : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentText;
    [SerializeField] private TMP_Text _nextLevelText;
    [SerializeField] private Game _game;

    private void Start()
    {
        _currentText.text = (_game.LevelIndex + 1).ToString();
        _nextLevelText.text = (_game.LevelIndex + 2).ToString(); 
    }
}
