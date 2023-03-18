using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoSingleton<PoolManager>
{
    [Header("CELL")] 
    [SerializeField] private Cell _cell;
    [HideInInspector] public ObjectPool<Cell> CellPool;
    
    [Header("BUILDINGS")] 
    [SerializeField] private BuildingBase _barrack;
    [SerializeField] private BuildingBase _house;
    [SerializeField] private BuildingBase _powerPlant;
    [SerializeField] private BuildingBase _soldierUnit;
    
    [HideInInspector] public ObjectPool<BuildingBase> BarrackPool;
    [HideInInspector] public ObjectPool<BuildingBase> HousePool;
    [HideInInspector] public ObjectPool<BuildingBase> PowerPlantPool;
    [HideInInspector] public ObjectPool<BuildingBase> SoldierUnitPool;
    
    [Header("SOLDIERS")]
    [SerializeField] private SoldierBase _level1Soldier;
    [SerializeField] private SoldierBase _level2Soldier;
    [SerializeField] private SoldierBase _level3Soldier;
    
    [HideInInspector] public ObjectPool<SoldierBase> Level1SoldierPool;
    [HideInInspector] public ObjectPool<SoldierBase> Level2SoldierPool;
    [HideInInspector] public ObjectPool<SoldierBase> Level3SoldierPool;
    
    [Header("SOLDIER BUTTONS")]
    [SerializeField] private SoldierButtonView _level1SoldierButton;
    [SerializeField] private SoldierButtonView _level2SoldierButton;
    [SerializeField] private SoldierButtonView _level3SoldierButton;
    
    [HideInInspector] public ObjectPool<SoldierButtonView> SoldierLevel1ButtonPool;
    [HideInInspector] public ObjectPool<SoldierButtonView> SoldierLevel2ButtonPool;
    [HideInInspector] public ObjectPool<SoldierButtonView> SoldierLevel3ButtonPool;
    
    
    public void EnablePoolObjects()
    {
        //CELL
        CellPool = new ObjectPool<Cell>(OnCreateCell, OnGetCell,
            OnReleaseCell, OnDestroyCell, false,1000, 1000);
        
        
        //BUILDINGS
        BarrackPool = new ObjectPool<BuildingBase>(OnCreateBarrack, OnGetBuilding,
            OnReleaseBuilding, OnDestroyBuilding, false,100, 100);
        
        HousePool = new ObjectPool<BuildingBase>(OnCreateHouse, OnGetBuilding,
            OnReleaseBuilding, OnDestroyBuilding, false,100, 100);
         
        PowerPlantPool = new ObjectPool<BuildingBase>(OnCreatePowePlant, OnGetBuilding,
            OnReleaseBuilding, OnDestroyBuilding, false,100, 100);
        
        SoldierUnitPool = new ObjectPool<BuildingBase>(OnCreateSoldierUnit, OnGetBuilding,
            OnReleaseBuilding, OnDestroyBuilding, false,100, 100);
        
        
        //SOLDIERS
        Level1SoldierPool = new ObjectPool<SoldierBase>(OnCreateLevel1Soldier, OnGetSoldier,
            OnReleaseSoldier, OnDestroySoldier, false,1000, 1000);
        
        Level2SoldierPool = new ObjectPool<SoldierBase>(OnCreateLevel2Soldier, OnGetSoldier,
            OnReleaseSoldier, OnDestroySoldier, false,1000, 1000);
        
        Level3SoldierPool = new ObjectPool<SoldierBase>(OnCreateLevel3Soldier, OnGetSoldier,
            OnReleaseSoldier, OnDestroySoldier, false,1000, 1000);
        
        
        //SOLDIER BUTTONS
        SoldierLevel1ButtonPool = new ObjectPool<SoldierButtonView>(OnCreateLevel1SoldierButton, OnGetSoldierButton,
            OnReleaseSoldierButton, OnDestroySoldierButton, false,100, 100);
        
        SoldierLevel2ButtonPool = new ObjectPool<SoldierButtonView>(OnCreateLevel2SoldierButton, OnGetSoldierButton,
            OnReleaseSoldierButton, OnDestroySoldierButton, false,100, 100);
        
        SoldierLevel3ButtonPool = new ObjectPool<SoldierButtonView>(OnCreateLevel3SoldierButton, OnGetSoldierButton,
            OnReleaseSoldierButton, OnDestroySoldierButton, false,100, 100);
    }

    #region Cell

    private Cell OnCreateCell()
    {
        return Instantiate(_cell);
    }
    
    private void OnGetCell(Cell obj)
    {
        obj.gameObject.SetActive(true);
    }
    
    private void OnReleaseCell(Cell obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(null);
        obj.transform.localScale = Vector3.one;
        obj.transform.position = Vector3.zero;
    }
    
    private void OnDestroyCell(Cell obj)
    {
        Destroy(obj.gameObject);
    }

    #endregion
    
    #region Buildings
    
    private BuildingBase OnCreateBarrack()
    {
        return Instantiate(_barrack);
    }
    
    private BuildingBase OnCreateHouse()
    {
        return Instantiate(_house);
    }
    
    private BuildingBase OnCreatePowePlant()
    {
        return Instantiate(_powerPlant);
    }
    
    private BuildingBase OnCreateSoldierUnit()
    {
        return Instantiate(_soldierUnit);
    }

    private void OnGetBuilding(BuildingBase obj)
    {
        obj.gameObject.SetActive(true);
    }
    
    private void OnReleaseBuilding(BuildingBase obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(null);
        obj.transform.localScale = Vector3.one;
        obj.transform.position = Vector3.zero;
    }
    
    private void OnDestroyBuilding(BuildingBase obj)
    {
        Destroy(obj.gameObject);
    }

    #endregion

    #region Soldiers

    private SoldierBase OnCreateLevel1Soldier()
    {
        return Instantiate(_level1Soldier);
    }
    
    private SoldierBase OnCreateLevel2Soldier()
    {
        return Instantiate(_level2Soldier);
    }
    
    private SoldierBase OnCreateLevel3Soldier()
    {
        return Instantiate(_level3Soldier);
    }
    
    private void OnGetSoldier(SoldierBase obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnReleaseSoldier(SoldierBase obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(null);
        obj.transform.localScale = Vector3.one;
        obj.transform.position = Vector3.zero;
    }

    private void OnDestroySoldier(SoldierBase obj)
    {
        Destroy(obj.gameObject);
    }

    #endregion

    #region Soldier Buttons

    private SoldierButtonView OnCreateLevel1SoldierButton()
    {
        return Instantiate(_level1SoldierButton);
    }
    
    private SoldierButtonView OnCreateLevel2SoldierButton()
    {
        return Instantiate(_level2SoldierButton);
    }
    
    private SoldierButtonView OnCreateLevel3SoldierButton()
    {
        return Instantiate(_level3SoldierButton);
    }
    
    private void OnGetSoldierButton(SoldierButtonView obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnReleaseSoldierButton(SoldierButtonView obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(null);
        obj.transform.localScale = Vector3.one;
        obj.transform.position = Vector3.zero;
    }

    private void OnDestroySoldierButton(SoldierButtonView obj)
    {
        Destroy(obj.gameObject);
    }

    #endregion
}
