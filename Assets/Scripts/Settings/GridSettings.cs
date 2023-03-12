using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = nameof(GridSettings), menuName = "ScriptableObject/" + nameof(GridSettings))]
public class GridSettings : ScriptableObject
{
   public Cell cell;
   public Vector2Int coordinateCount;
   public Color canBuildColor;
   public Color cantBuildColor;
}
