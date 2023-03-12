using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Transform map;
    public Transform grid;
    public Transform build;
    public GameObject mouseTarget;
    public void CreateMap()
    {
        MouseTargetEnable(false);
    }

    public void MouseTargetEnable(bool isActive)
    {
       
    }
}
