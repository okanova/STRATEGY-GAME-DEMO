using System.Collections.Generic;
using Extensions;
using Settings;
using Soldiers;
using UnityEngine;

namespace Managers
{
    public class BuildingManager : MonoSingleton<BuildingManager>
    {
        public List<BuildingBase> buildings;
    
        private BuildingBase _tempBuilding;

        public BuildingSettings buildingSettings;

        public Barrack spawnerBarrack;
    
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

        public void CreateSoldier(SoldierType type)
        {
            SoldierBase Soldier() => (type) switch
            {
                (SoldierType.Level1) => PoolManager.Instance.Level1SoldierPool.Get(),
                (SoldierType.Level2) => PoolManager.Instance.Level2SoldierPool.Get(),
                (SoldierType.Level3) => PoolManager.Instance.Level3SoldierPool.Get(),
                (_) => null
            };

            foreach (var nest in spawnerBarrack.nestPositionList)
            {
                if (nest.spawnPoint)
                {
                    Soldier().transform.position = GridManager.Instance.coordinateX[Mathf.RoundToInt
                            (nest.nestPosition.x + spawnerBarrack.transform.localPosition.x)].coordinateY[
                            Mathf.RoundToInt(nest.nestPosition.y + spawnerBarrack.transform.localPosition.y)]
                        .transform.position;
                }
            }
        }
    }
}
