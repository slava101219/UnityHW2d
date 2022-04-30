using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _amountHPChanges = 10;

    private int _minHealth = 0;
    private int _healthPoint = 50;
    public int MaxHealth { get; private set; } = 100;
    public int HealthPoint
    {
        get { return _healthPoint; }
        private set
        {
            _healthPoint = Mathf.Clamp(value, _minHealth, MaxHealth);
        }
    }

    public delegate void ChangeSliderValue();
    public event ChangeSliderValue ReportForSliderValue;

    public void HPValueAdd()
    {

        HealthPoint += _amountHPChanges;
        ReportForSliderValue?.Invoke();
    }

    public void HpValueTake()
    {
        HealthPoint -= _amountHPChanges;
        ReportForSliderValue?.Invoke();
    }
}
