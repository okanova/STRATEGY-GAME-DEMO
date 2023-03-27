using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Environment.Grid;
using Interfaces;
using Managers;
using UnityEngine;

namespace Soldiers
{
    public class SoldierBase : MonoBehaviour, IAttacker
    {
        public SoldierType soldierType;
        [SerializeField] private GameObject _model;
        private List<Vector2> _targetPositions = new List<Vector2>();

        private void OnMouseUp()
        {
            SoldierEnabled();
            _targetPositions.Clear();
        }

        private void SoldierEnabled()
        {
            InputManager.OnLeftMouseDownEvent += SoldierDisabled;
            InputManager.OnRightMouseDownEvent += FindTarget;
        }
        
        private void SoldierDisabled()
        {
            InputManager.OnLeftMouseDownEvent -= SoldierDisabled;
            InputManager.OnRightMouseDownEvent -= FindTarget;
        }
        

        private void FindTarget()
        {
            SoldierDisabled();

            Cell startCell = GridManager.Instance.coordinateX[(int) transform.position.x]
                .coordinateY[(int) transform.position.y];

            Cell targetCell = startCell;
            
            Ray ray = GameManager.Instance.camera.mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
              targetCell = GridManager.Instance.cells.OrderBy(cell => cell.walkable ? 0 : 1)
                    .ThenBy(cell => Vector2.Distance(hit.point, cell.transform.position)).First();
            }

            _targetPositions = PathFinding.Instance.FindPathTransforms(startCell, targetCell);
            StartCoroutine("MovementRoutine");
        }


        IEnumerator MovementRoutine()
        {
            yield return new WaitForSeconds(0.5f);
            
            int count = 0;

            while (count < _targetPositions.Count)
            {
                
                transform.position = Vector3.Lerp(transform.position, _targetPositions[count], 0.1f);

                if (Vector3.Distance(transform.position, _targetPositions[count]) < 0.1f)
                {
                    count++;
                }
                yield return null;
            }
        }
    }
}
