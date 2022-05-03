using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HPSlider : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _changeValue;
    private float _speed = 0.5f;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeSliderValue;
    }

    private void Start()
    {        
        _slider = GetComponent<Slider>();
        _slider.value = (float)_player.HealthPoint / (float)_player.MaxHealth;
    }

    private void ChangeSliderValue()
    {
        if(_changeValue != null)
        {
            StopCoroutine(_changeValue);
        }

        _changeValue = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        float targetValue = (float)_player.HealthPoint / (float)_player.MaxHealth;
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
}
