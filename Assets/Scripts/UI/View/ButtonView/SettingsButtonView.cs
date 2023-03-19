using UnityEngine;

namespace UI.View.ButtonView
{
    public class SettingsButtonView : BaseButtonView
    {
        [SerializeField] private GameObject _settingsPanel;
        protected override void OnButtonClick()
        {
            if (_settingsPanel.activeSelf)
            {
                _settingsPanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                _settingsPanel.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
    }
}
