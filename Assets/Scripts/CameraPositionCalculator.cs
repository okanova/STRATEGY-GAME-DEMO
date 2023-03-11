using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionCalculator : MonoBehaviour
{
   public CameraSettings cameraSettings;
   [SerializeField] private Camera camera;
   public void CameraDivergence(Vector2 coordinate)
   {
      camera.transform.position = new Vector3(-0.5f + coordinate.x / 2, -0.5f + coordinate.y / 2, -1);
      
     
      camera.orthographicSize += cameraSettings.divergenceValue * Mathf.Max(coordinate.y, coordinate.x) * 
                                 ((1920 / 1080f) / (camera.pixelWidth / (camera.pixelHeight * 1f)));
   }
}
