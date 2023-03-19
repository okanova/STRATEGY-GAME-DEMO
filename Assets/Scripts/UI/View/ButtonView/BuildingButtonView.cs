using Interfaces;
using Managers;
using UnityEngine;

namespace UI.View.ButtonView
{
    public class BuildingButtonView : BaseButtonView, IGoldChanger
    {
        [SerializeField] private BuildingType _buildingType;
        private int _cost;
        
        
        protected override void OnButtonClick()
        {
            
            foreach (var building in BuildingManager.Instance.buildingSettings.buildingTypeValuesList)
            {
                if (building.buildingType == _buildingType)
                    _cost = building.cost;
            }
            
            if (!CheckGold()) return;

            //ChangeGold(UIManager.Instance.SourceController.SourceModel.currentMoney - _cost);
            BuildingManager.Instance.CreateNewBuilding(_buildingType);
        }

        public bool CheckGold()
        {
            if (UIManager.Instance.SourceController.SourceModel.currentMoney - _cost >= 0)
                return true;

            return false;
        }

        public void ChangeGold(int gold)
        {
           
        }
    }
}
