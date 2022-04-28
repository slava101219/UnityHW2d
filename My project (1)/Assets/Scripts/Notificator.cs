using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificator : MonoBehaviour
{   
    public delegate void ChangeHP(bool isAdd);
    public event ChangeHP ReportForHP;
    
    public void ClickOnIncreaseButton()
    {
        ReportForHP?.Invoke(true);       
    }

    public void ClickOnDecreaseButton()
    {
        ReportForHP?.Invoke(false);
    }
}
