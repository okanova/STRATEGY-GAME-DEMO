using UnityEngine;

namespace Settings
{
   [CreateAssetMenu (fileName = nameof(CameraSettings), menuName = "ScriptableObject/" + nameof(CameraSettings))]
   public class CameraSettings : ScriptableObject
   {
      public float divergenceValue;
   }
}
