using Environment.Grid;
using UnityEngine;

namespace Settings
{
   [CreateAssetMenu (fileName = nameof(GridSettings), menuName = "ScriptableObject/" + nameof(GridSettings))]
   public class GridSettings : ScriptableObject
   {
      public Cell cell;
      public Vector2Int coordinateCount;
   }
}
