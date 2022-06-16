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
    private Animator _animator;

    private void Start()
    {
        _animator = _player.GetComponent<Animator>();
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnGameOvered;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnGameOvered;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }
    
    private void OnGameOvered()
    {
        _animator.SetBool("Died", true);
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
