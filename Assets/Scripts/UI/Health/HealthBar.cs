using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heart;

    private List<Heart> _list = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        
        if (_list.Count < value)
        {
            int createHeart = value - _list.Count;
            for (int i = 0; i < createHeart; i++)
            {
                CreateHeart();
            }
        }
        else if (_list.Count > value && _list.Count != 0)
        {
            int createHeart = _list.Count - value;
            for (int i = 0; i < createHeart; i++)
            {
                DestroyHeart(_list[_list.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _list.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heart, transform);
        _list.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}
