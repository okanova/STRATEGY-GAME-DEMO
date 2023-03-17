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

    private List<Cell> _paintedCells = new List<Cell>();
    
    public void AddCell(Transform parent)
    {
        Cell tempCell;
        
        for (int x = 0; x < gridSettings.coordinateCount.x; x++)
        {
            for (int y = 0; y < gridSettings.coordinateCount.y; y++)
            {
                tempCell = PoolManager.Instance.CellPool.Get().GetComponent<Cell>();
                tempCell.transform.SetParent(parent);
                tempCell.transform.localPosition = new Vector2(x, y);
                coordinateX[x].coordinateY[y] = tempCell;
                tempCell.SetFirstColor();
                tempCell.name = x + "_" + y;
            }
        }
    }

    public bool CellIsEmpty(Vector2Int cellPos)
    {
        if (cellPos.x < 0 || cellPos.x >= gridSettings.coordinateCount.x || 
            cellPos.y < 0 || cellPos.y >= gridSettings.coordinateCount.y)
            return false;
        
        _paintedCells.Add(coordinateX[cellPos.x].coordinateY[cellPos.y]);
        coordinateX[cellPos.x].coordinateY[cellPos.y].ColorEnable();
       
        if (coordinateX[cellPos.x].coordinateY[cellPos.y].isEmpty)
            return true;
        
        return false;
    }

    public void NotCorrectPoint() //if every cells not empty, all cells will be red
    {
        foreach (var cell in _paintedCells)
        {
            cell.ColorRed();
        }
    }

    public void BuildOnCell()
    {
        foreach (var cell in _paintedCells)
        {
            cell.ColorDisable();
            cell.isEmpty = false;
        }
        
        _paintedCells.Clear();
    }

    public void ClearCellList()
    {
        if (_paintedCells.Count == 0) return;
        
        foreach (var cell in _paintedCells)
        {
            cell.ColorDisable();
        }
        
        _paintedCells.Clear();
    }
}


[Serializable]
public class CoordinateClass
{
    public Cell[] coordinateY = new Cell[100];
}
