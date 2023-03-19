using Managers;
using UnityEngine;


public class Barrack : BuildingBase
{
    [SerializeField] private Vector2 _door;
    Vector2 _tempPos;
    
    protected override void RotationNinetyDegrees()
    {
        _models[0].transform.eulerAngles += Vector3.forward * 90;
        _models[1].transform.eulerAngles += Vector3.forward * 90;
        for (int i = 0; i < nestPositionList.Length; i++)
        {
            _tempPos = nestPositionList[i].nestPosition - center;
            nestPositionList[i].nestPosition = new Vector2(-_tempPos.y, _tempPos.x);
            nestPositionList[i].nestPosition += center;
        }
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        BuildingManager.Instance.spawnerBarrack = this;
    }
}
