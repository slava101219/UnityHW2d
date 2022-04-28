using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _amountHPChanges = 10;
    [SerializeField] private Notificator _notificator;

    private int _minHealth = 0;
    private int _healthPoint = 50;
    public int MaxHealth { get; private set; } = 100;
    public int HealthPoint
    {
        get { return _healthPoint; }
        private set
        {
            if (value < _minHealth) 
            { 
                _healthPoint = _minHealth; 
            }
            else if (value > MaxHealth) 
            {
                _healthPoint = MaxHealth; 
            }
            else 
            { 
                _healthPoint = value; 
            }
        }
    }

    public delegate void ChangeSliderValue();
    public event ChangeSliderValue ReportForSliderValue;

    private void Start()
    {
        _notificator.ReportForHP += ChangeHPValue;
    }

    private void ChangeHPValue(bool Adds)
    {
        if (Adds) 
        { 
            HealthPoint += _amountHPChanges; 
        }
        else if (Adds == false) 
        { 
            HealthPoint -= _amountHPChanges; 
        }

        ReportForSliderValue?.Invoke();
    }
}
