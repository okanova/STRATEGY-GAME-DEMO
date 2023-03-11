using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
    public GridSettings gridSettings;
    
    public CoordinateClass[] coordinateX = new CoordinateClass[100];

    public List<Cell> cells;
    
    public void AddCell(Transform parent)
    {
        Cell tempCell;
        
        for (int x = 0; x < gridSettings.coordinateCount.x; x++)
        {
            for (int y = 0; y < gridSettings.coordinateCount.y; y++)
            {
                tempCell = Instantiate(gridSettings.cell);
                tempCell.transform.SetParent(parent);
                tempCell.transform.localPosition = new Vector2(x, y);
                coordinateX[x].coordinateY[y] = tempCell;
                cells.Add(tempCell);
            }
        }
    }
}

[Serializable]
public class CoordinateClass
{
    public Cell[] coordinateY = new Cell[100];
}
