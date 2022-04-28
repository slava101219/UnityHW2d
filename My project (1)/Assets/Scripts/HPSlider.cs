using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HPSlider : MonoBehaviour
{
    [SerializeField] private Button _buttonIncreases;
    [SerializeField] private Button _buttonDecreases;
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _changeValue;
    private float _speed = 0.5f;

    private void Start()
    {
        _player.ReportForSliderValue += ChangeSliderValue;
        _slider = GetComponent<Slider>();
        _slider.value = (float)_player.HealthPoint / (float)_player.MaxHealth;
    }

    private void ChangeSliderValue()
    {
        if(_changeValue != null)
        {
            StopCoroutine(_changeValue);
            _changeValue = null;
        }

        _changeValue = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        _buttonIncreases.interactable = false;
        _buttonDecreases.interactable = false;
        float targetValue = (float)_player.HealthPoint / (float)_player.MaxHealth;
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
        _buttonIncreases.interactable = true;
        _buttonDecreases.interactable = true;
        yield break;
    }
}
