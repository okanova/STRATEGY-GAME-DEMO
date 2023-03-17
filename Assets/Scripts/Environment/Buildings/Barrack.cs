using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : BuildingBase
{
    [SerializeField] private Vector2 _door;

    public override void RotationNinetyDegrees()
    {
        Vector2 tempPos;
        _models[0].transform.eulerAngles += Vector3.forward * 90;
        _models[1].transform.eulerAngles += Vector3.forward * 90;
        for (int i = 0; i < _nestPositionList.Count; i++)
        {
            tempPos = _nestPositionList[i] - center;
            _nestPositionList[i] = new Vector2(-tempPos.y, tempPos.x);
            _nestPositionList[i] += center;
        }
    }
}
