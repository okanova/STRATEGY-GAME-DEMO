using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject[] _cellModels;

    public bool isEmpty;

    private Color[] _colors = new Color[3];
    public void SetFirstColor()
    {
        isEmpty = true;
        ColorDisable();
    }
    
    
    public void ColorEnable()
    {
        if (isEmpty)
           OpenOneCell(1);
        else
            OpenOneCell(2);
    }

    public void ColorRed()
    {
        OpenOneCell(2);
    }

    public void ColorDisable()
    {
        OpenOneCell(0);
    }

    private void OpenOneCell(int count)
    {
        foreach (var cell in _cellModels)
        {
            cell.SetActive(false);
        }
        
        _cellModels[count].SetActive(true);
    }
}
