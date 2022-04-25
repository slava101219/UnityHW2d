using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    [SerializeField] private Button _buttonIncreases;
    [SerializeField] private Button _buttonDecreases;

    private Slider _hpSlider;
    private Coroutine _changeValue;
    private float _increaseHp = 0.1f;
    private float _decreaseHp = -0.1f;
    private float _speed = 0.5f;

    private void Start()
    {
        _hpSlider = GetComponent<Slider>();
    }

    public void ChageHPValue(bool increases)
    {
        if(_changeValue != null)
        {
            StopCoroutine(_changeValue);
            _changeValue = null;
        }

        if (increases)
        {
            _changeValue = StartCoroutine(IncreaseHP());
            

        }
        else if (increases == false)
        {
            _changeValue = StartCoroutine(DecreaseHP());
        }
    }

    private IEnumerator IncreaseHP()
    {
        _buttonIncreases.interactable = false;
        float targetValue = _hpSlider.value + _increaseHp;
        while (_hpSlider.value != targetValue)
        {
            _hpSlider.value = Mathf.MoveTowards(_hpSlider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
        _buttonIncreases.interactable = true;
        yield break;
    }

    private IEnumerator DecreaseHP()
    {
        _buttonDecreases.interactable = false;
        float targetValue = _hpSlider.value + _decreaseHp;
        while (_hpSlider.value != targetValue)
        {
            _hpSlider.value = Mathf.MoveTowards(_hpSlider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
        _buttonDecreases.interactable = true;
        yield break;
    }
}
