using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private GameObject _cell;
    [HideInInspector] public ObjectPool<GameObject> CellPool;
    
    [Header("BUILDINGS")] 
    [SerializeField] private GameObject _barrack;
    [SerializeField] private GameObject _house;
    [SerializeField] private GameObject _powerPlant;
    [SerializeField] private GameObject _soldierUnit;
    
    [HideInInspector] public ObjectPool<GameObject> BarrackPool;
    [HideInInspector] public ObjectPool<GameObject> HousePool;
    [HideInInspector] public ObjectPool<GameObject> PowerPlantPool;
    [HideInInspector] public ObjectPool<GameObject> SoldierUnitPool;
    
    public void EnablePoolObjects()
    {
        CellPool = new ObjectPool<GameObject>(OnCreateCell, OnGetObject,
            OnReleaseObject, OnDestroyObj, false,1000, 1000);
        
        BarrackPool = new ObjectPool<GameObject>(OnCreateBarrack, OnGetObject,
            OnReleaseObject, OnDestroyObj, false,100, 100);
        
        HousePool = new ObjectPool<GameObject>(OnCreateHouse, OnGetObject,
            OnReleaseObject, OnDestroyObj, false,100, 100);
         
        PowerPlantPool = new ObjectPool<GameObject>(OnCreatePowePlant, OnGetObject,
            OnReleaseObject, OnDestroyObj, false,100, 100);
        
        SoldierUnitPool = new ObjectPool<GameObject>(OnCreateSoldierUnit, OnGetObject,
            OnReleaseObject, OnDestroyObj, false,100, 100);
    }
    
    private GameObject OnCreateCell()
    {
        return Instantiate(_cell);
    }

    private GameObject OnCreateBarrack()
    {
        return Instantiate(_barrack);
    }
    
    private GameObject OnCreateHouse()
    {
        return Instantiate(_barrack);
    }
    
    private GameObject OnCreatePowePlant()
    {
        return Instantiate(_barrack);
    }
    
    private GameObject OnCreateSoldierUnit()
    {
        return Instantiate(_barrack);
    }

    private void OnGetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(null);
        obj.transform.localScale = Vector3.one;
        obj.transform.position = Vector3.zero;
    }

    private void OnDestroyObj(GameObject obj)
    {
        Destroy(obj);
    }
}
