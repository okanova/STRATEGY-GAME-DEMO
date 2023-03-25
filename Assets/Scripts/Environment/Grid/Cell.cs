using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Environment.Grid
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private GameObject[] _cellModels;

        public bool isEmpty;
        public bool walkable;

        private Color[] _colors = new Color[3];

        public List<Cell> neightborsList;

        
        public void EnableCell()
        {
            SetFirstColor();
            StartCoroutine(FindNeightbors());
        }
        
        private void SetFirstColor()
        {
            isEmpty = true;
            walkable = true;
            ColorDisable();
        }

        private IEnumerator FindNeightbors()
        {
            yield return new WaitForSeconds(0.1f);
            CheckZoneLimit(Vector2Int.RoundToInt(transform.localPosition + Vector3.right));
            CheckZoneLimit(Vector2Int.RoundToInt(transform.localPosition + Vector3.left));
            CheckZoneLimit(Vector2Int.RoundToInt(transform.localPosition + Vector3.up));
            CheckZoneLimit(Vector2Int.RoundToInt(transform.localPosition + Vector3.down));
        }

        private void CheckZoneLimit(Vector2Int cellPos)
        {
            if (cellPos.x < 0 || cellPos.x >= GridManager.Instance.gridSettings.coordinateCount.x || 
                cellPos.y < 0 || cellPos.y >= GridManager.Instance.gridSettings.coordinateCount.y)
                return;
            
            neightborsList.Add(GridManager.Instance.coordinateX[cellPos.x].coordinateY[cellPos.y]);
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
}
