using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = nameof(CameraSettings), menuName = "ScriptableObject/" + nameof(CameraSettings))]
public class CameraSettings : ScriptableObject
{
   public float divergenceValue;
}
