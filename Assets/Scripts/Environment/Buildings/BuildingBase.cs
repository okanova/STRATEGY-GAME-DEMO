using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
   [SerializeField] private List<Vector2> _nestPositionList;
   [SerializeField] private BuildingType _type;

   private bool _correctPoint;


   #region Create & Set

   public void BuildingSearcherEnabled()
   {
      StartCoroutine("BuildingMovementRoutine");
      StartCoroutine("CheckCellsSituationtRoutine");
   }

   public void BuildingSearcherDisabled()
   {
      StopCoroutine("BuildingMovementRoutine");
      StopCoroutine("CheckCellsSituationtRoutine");
      
      GridManager.Instance.BuildOnCell();

      if (_correctPoint)
         transform.localPosition = Vector3Int.RoundToInt(transform.localPosition);
      
      if (!_correctPoint) Destroy(gameObject);
   }
   

   private IEnumerator CheckCellsSituationtRoutine()
   {
      while (true)
      {
         int count = FindEmptyCellsCount();
         
         if (count == _nestPositionList.Count)
            _correctPoint = true;
         else 
            _correctPoint = false;
         
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
      foreach (var pos in _nestPositionList)
      {
         if (GridManager.Instance.CellIsEmpty(Vector2Int.RoundToInt((Vector2) transform.localPosition + pos)))
         {
            count++;
         }
      }

      return count;
   }

   #endregion

   private void OnMouseUp()
   {
       UIManager.Instance.OpenPanel(_type);
   }
}
