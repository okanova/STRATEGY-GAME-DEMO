using System;
using System.Collections;
using System.Collections.Generic;
using Environment.Grid;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class PathFinding : MonoBehaviour
    {
        public List<Cell> _walkableList = new List<Cell>();
        public List<Vector3> _pathTransforms = new List<Vector3>();
        
        public PathClass[] pathClass = new PathClass[1000];
        public Cell StartCell { get; private set; }
        public Cell EndCell { get; private set; }
        
        public Transform obj;
        
        private int c = 0;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCell = GridManager.Instance.cells[Random.Range(0, GridManager.Instance.cells.Count)];
                EndCell = GridManager.Instance.cells[Random.Range(0, GridManager.Instance.cells.Count)];
                FindPathTransforms(StartCell, EndCell);
                StartCoroutine(delay());

            }

            
        }

        IEnumerator delay()
        {
            yield return new WaitForSeconds(1f);

            while (true)
            {
                obj.transform.position = Vector3.Lerp(obj.transform.position, _pathTransforms[c], 0.01f);

                if (Vector3.Distance(obj.transform.position, _pathTransforms[c]) < 0.1f)
                {
                    c++;
                }

                yield return null;
            }
           
        }

        public List<Vector3> FindPathTransforms(Cell start, Cell end)
        {
            StartCell = start;
            EndCell = end;
            FindWalkableCells();
            ClearPathList();
            
            return _pathTransforms;
        }

        private void ClearPathList()
        {
            foreach (var path in pathClass)
            {
                path.isActive = false;
            }

            pathClass[0].cell = StartCell;
            pathClass[0].isActive = true;
            tempCell = StartCell;
            StartCoroutine(AddPath());
        }
        

        private void FindWalkableCells()
        {
            _walkableList.Clear();

            foreach (var cell in GridManager.Instance.cells)
            {
                if (cell.walkable)
                    _walkableList.Add(cell);
            }
        }

        private Cell tempCell;
        private int tempCellCount;
        
        private IEnumerator AddPath()
        {
            while (tempCell != EndCell)
            {
               
                int control = 0;
                
                foreach (var neightborCell in tempCell.neightborsList)
                {
                    if (!neightborCell.walkable)
                    {
                        control++;
                        continue;
                    }

                    if (!CheckList(neightborCell))
                    {
                        control++;
                        continue;
                    }
                    int count = FindEmptySlot();
                    pathClass[count].cell = neightborCell;
                    pathClass[count].isActive = true;
                    pathClass[count].gN_current = pathClass[tempCellCount].gN_current + 1;
                    pathClass[count].fN_heuristic = Vector2.Distance(
                        pathClass[count].cell.transform.position, EndCell.transform.position);

                    pathClass[count].hN_total = pathClass[count].gN_current + pathClass[count].fN_heuristic;
                    pathClass[count].previousRoad = tempCellCount;
                }

                if (control == tempCell.neightborsList.Count)
                {
                    pathClass[tempCellCount].hN_total = 1000;
                }
                
                NearestPosition();
                yield return null;
            }
            
            AddPositionsInPath();
           // _pathTransforms = pathClass[cellCount].previousRoads;
        }

        
        private bool CheckList(Cell cell)
        {
            for (int i = 0; i < pathClass.Length; i++)
            {
                if (!pathClass[i].isActive)
                    return true;

                if (pathClass[i].cell == cell)
                    return false;
            }

            return false;
        }

        private int FindEmptySlot()
        {
            int count = 0;

            for (int i = 0; i < pathClass.Length; i++)
            {
                if (!pathClass[i].isActive)
                {
                    count = i;
                    break;
                }
            }

            return count;
        }


        private void NearestPosition()
        {
            int count = 0;
            float min = 1000;
            
            for (int i = 0; i < pathClass.Length; i++)
            {
                if (!pathClass[i].isActive)
                    break;

                if (pathClass[i].hN_total < min && pathClass[i].hN_total > 0)
                {
                    min = pathClass[i].hN_total;
                    count = i;
                }
            }

            tempCellCount = count;
            tempCell = pathClass[count].cell;
        }
        
        private void AddPositionsInPath()
        {
            while (tempCellCount > 0)
            {
                _pathTransforms.Add(pathClass[tempCellCount].cell.transform.position);
                tempCellCount = pathClass[tempCellCount].previousRoad;
            }
           
            _pathTransforms.Reverse();
        }
    }
    
    
    [Serializable]
    public class PathClass
    {
        public Cell cell;
        public float hN_total;
        public float gN_current;
        public float fN_heuristic;
        public int previousRoad;
        public bool isActive;
    }
}

