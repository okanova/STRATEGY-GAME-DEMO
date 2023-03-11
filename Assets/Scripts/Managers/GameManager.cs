using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("GAME OBJECTS")]
    public Environment environment;
    public CameraPositionCalculator camera;
    
  
    private IEnumerator Start()
    {
        Environment tempEnvironment = Instantiate(environment);
        tempEnvironment.CreateMap();
        camera.CameraDivergence(GridManager.Instance.gridSettings.coordinateCount);
        yield return null;
        GridManager.Instance.AddCell(tempEnvironment.grid);
    }
}
