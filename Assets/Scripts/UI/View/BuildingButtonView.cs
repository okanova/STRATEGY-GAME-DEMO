using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtonView : BaseButtonView
{
    [SerializeField] private BuildingType _buildingType;
    protected override void OnButtonClick()
    {
        BuildingManager.Instance.CreateNewBuilding(_buildingType);
    }
    
}
