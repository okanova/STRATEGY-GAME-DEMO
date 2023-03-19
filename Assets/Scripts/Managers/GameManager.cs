using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [Header("GAME OBJECTS")]
        public Environment.Environment environment;
        public CameraPositionCalculator camera;
    
  
        private IEnumerator Start()
        {
            PoolManager.Instance.EnablePoolObjects();
            environment = Instantiate(environment);
            environment.CreateMap();
            camera.CameraDivergence(GridManager.Instance.gridSettings.coordinateCount);
            yield return null;
            GridManager.Instance.AddCell(environment.grid);
            camera.SideCamerasActiveChange(true);
            UIManager.Instance.UIEnabled();
            InputManager.Instance.MouseEnabled();
        }
    }

    public enum BuildingType
    {
        Barrack,
        House,
        PowerPlant,
        SoldierUnit
    }

    public enum SoldierType
    {
        Level1, 
        Level2,
        Level3
    }
}