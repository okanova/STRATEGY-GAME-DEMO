using UnityEngine;


public class Barrack : BuildingBase
{
    [SerializeField] private Vector2 _door;
    Vector2 _tempPos;
    
    protected override void RotationNinetyDegrees()
    {
        _models[0].transform.eulerAngles += Vector3.forward * 90;
        _models[1].transform.eulerAngles += Vector3.forward * 90;
        for (int i = 0; i < _nestPositionList.Length; i++)
        {
            _tempPos = _nestPositionList[i].nestPosition - center;
            _nestPositionList[i].nestPosition = new Vector2(-_tempPos.y, _tempPos.x);
            _nestPositionList[i].nestPosition += center;
        }
    }
}
