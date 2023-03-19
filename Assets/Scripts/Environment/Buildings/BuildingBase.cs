using System;
using System.Collections;
using Interfaces;
using Managers;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour, IGoldChanger
{
   public NestPositionClass[] nestPositionList;
   [SerializeField] protected Vector2 center;
   [SerializeField] protected GameObject[] _models;
   [SerializeField] private BuildingType _buildingType;
   private int _cost;
   
   private bool _correctPoint;

   #region Create & Movement & SetOrDestroy

   public void BuildingMovementEnabled()
   {
      _models[0].SetActive(false);
      _models[1].SetActive(true);
      
      RotationEnabled();
      StartCoroutine("BuildingMovementRoutine");
      StartCoroutine("CheckCellsSituationtRoutine");
   }

   public void BuildingMovementDisabled()
   {
      RotationDisabled();
      StopCoroutine("BuildingMovementRoutine");
      StopCoroutine("CheckCellsSituationtRoutine");
      
      if (_correctPoint) //SET 
      {
         SetBuilding();
      }
      else //DESTROY
      {
         GridManager.Instance.ClearCellList();
         Destroy(gameObject);
      }
   }

   protected virtual void SetBuilding()
   {
      _models[0].SetActive(true);
      _models[1].SetActive(false);
         
      GridManager.Instance.BuildOnCell();
      transform.localPosition = Vector3Int.RoundToInt(transform.localPosition);
      
      foreach (var building in BuildingManager.Instance.buildingSettings.buildingTypeValuesList)
      {
         if (building.buildingType == _buildingType)
            _cost = building.cost;
      }

      ChangeGold(UIManager.Instance.SourceController.SourceModel.currentMoney - _cost);
   }

   private IEnumerator CheckCellsSituationtRoutine()
   {
      while (true)
      {
         int count = FindEmptyCellsCount();
         
         if (count == nestPositionList.Length)
            _correctPoint = true;
         else 
            _correctPoint = false;
         
         if (!_correctPoint)
            GridManager.Instance.NotCorrectPoint();
            
         yield return null;

         GridManager.Instance.ClearCellList();
      }
   }

   private IEnumerator BuildingMovementRoutine()
   {
      while (true)
      {
         Ray ray = GameManager.Instance.camera.mainCamera.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit))
            transform.position = hit.point;

         yield return new WaitForFixedUpdate();
      }
   }

   private int FindEmptyCellsCount()
   {
      int count = 0;
      foreach (var pos in nestPositionList)
      {
         if (GridManager.Instance.CellIsEmpty(Vector2Int.RoundToInt((Vector2) transform.localPosition + pos.nestPosition)))
         {
            count++;
         }
      }

      return count;
   }

   #endregion
   
   #region Rotation

   private void RotationEnabled()
   {
      InputManager.OnRightMouseDownEvent += RotationNinetyDegrees;
   }

   private void RotationDisabled()
   {
      InputManager.OnRightMouseDownEvent -= RotationNinetyDegrees;
   }


   protected virtual void RotationNinetyDegrees()
   {
     
   }

   #endregion
   
   protected virtual void OnMouseUp()
   {
      UIManager.Instance.OpenPanel(_buildingType);
   }

   public bool CheckGold()
   {
      return true;
   }

   public void ChangeGold(int gold)
   {
      UIManager.Instance.GoldInvoke(gold);
   }
}


[Serializable]
public class NestPositionClass
{
   public Vector2 nestPosition;
   public bool walkable;
   public bool spawnPoint;
}
