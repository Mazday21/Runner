using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;

    private CanvasGroup _gameOverGroup;

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnGameOvered;
    }

    private void OnDisable()
    {
        _player.Died -= OnGameOvered;
    }
    
    private void OnGameOvered()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
