using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificator : MonoBehaviour
{
    public delegate void ChangeSliderValue();
    public delegate void ChangeHP(bool isAdd);
    public event ChangeSliderValue ReportForSliderValue;
    public event ChangeHP ReportForHP;
    
    public void ClickOnIncreaseButton()
    {
        ReportForHP?.Invoke(true);
        ReportForSliderValue?.Invoke();       
    }

    public void ClickOnDecreaseButton()
    {
        ReportForHP?.Invoke(false);
        ReportForSliderValue?.Invoke();
    }
}
