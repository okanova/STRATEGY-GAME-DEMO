using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonView : BaseButtonView
{
    [SerializeField] private GameObject _settingsPanel;
    
    
    protected override void OnButtonClick()
    {
        Time.timeScale = 1;
        _settingsPanel.SetActive(false);
    }
}
