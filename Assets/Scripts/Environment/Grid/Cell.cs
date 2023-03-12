using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _cellModel;
    [SerializeField] private SpriteRenderer _renderer;
    private Color _firstColor;
    
    public bool isEmpty;

    public void SetFirstColor()
    {
        _firstColor = _renderer.material.GetColor("_Color");
        isEmpty = true;
    }
    
    
    public void ColorEnable()
    {
        if (isEmpty)
            _renderer.material.SetColor("_Color", GridManager.Instance.gridSettings.canBuildColor);
        else
            _renderer.material.SetColor("_Color", GridManager.Instance.gridSettings.cantBuildColor);
    }

    public void ColorDisable()
    {
        _renderer.material.SetColor("_Color", _firstColor);
    }
    
    
}
