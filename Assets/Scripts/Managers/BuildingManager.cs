using System.Collections.Generic;
using Extensions;
using Settings;

namespace Managers
{
    public class BuildingManager : MonoSingleton<BuildingManager>
    {
        public List<BuildingBase> buildings;
    
        private BuildingBase _tempBuilding;

        public BuildingSettings buildingSettings;
    
    
        public void CreateNewBuilding(BuildingType type)
        {
            BuildingBase Building() => (type) switch
            {
                (BuildingType.Barrack) => PoolManager.Instance.BarrackPool.Get(),
                (BuildingType.House) => PoolManager.Instance.HousePool.Get(),
                (BuildingType.PowerPlant) => PoolManager.Instance.PowerPlantPool.Get(),
                (BuildingType.SoldierUnit) => PoolManager.Instance.SoldierUnitPool.Get(),
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
}
