using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoSingleton<BuildingManager>
{
    public List<BuildingBase> buildings;
    
    private BuildingBase _tempBuilding;

    public BuildingSettings _buildingSettings;
    
    
    public void CreateNewBuilding(BuildingType type)
    {
        BuildingBase Building() => (type) switch
        {
            (BuildingType.Barrack) => PoolManager.Instance.BarrackPool.Get().GetComponent<BuildingBase>(),
            (BuildingType.House) => PoolManager.Instance.HousePool.Get().GetComponent<BuildingBase>(),
            (BuildingType.PowerPlant) => PoolManager.Instance.PowerPlantPool.Get().GetComponent<BuildingBase>(),
            (BuildingType.SoldierUnit) => PoolManager.Instance.SoldierUnitPool.Get().GetComponent<BuildingBase>(),
            (_) => null
        };

        _tempBuilding = Building();
        buildings.Add(_tempBuilding);
        BuildingEnabled();
    }

    private void BuildingEnabled()
    {
        _tempBuilding.transform.SetParent(GameManager.Instance.environment.build);
        GameManager.Instance.camera.SideCamerasActiveChange(false);
        UIManager.Instance.ClosePanel();
        _tempBuilding.BuildingMovementEnabled();
        InputManager.OnLeftMouseUpEvent += BuildingDisabled;
    }

    private void BuildingDisabled()
    {
        GameManager.Instance.camera.SideCamerasActiveChange(true);
        _tempBuilding.BuildingMovementDisabled();
        InputManager.OnLeftMouseUpEvent -= BuildingDisabled;
    }
}
