using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionCalculator : MonoBehaviour
{
   public CameraSettings cameraSettings;
   public Camera mainCamera;
   [SerializeField] private GameObject leftCamera;
   [SerializeField] private GameObject rightCamera;
   
   public void CameraDivergence(Vector2 coordinate)
   {
      mainCamera.transform.position = new Vector3(-0.5f + coordinate.x / 2, -0.5f + coordinate.y / 2, -1);
      
     
      mainCamera.orthographicSize += cameraSettings.divergenceValue * Mathf.Max(coordinate.y, coordinate.x) * 
                                 ((1920 / 1080f) / (mainCamera.pixelWidth / (mainCamera.pixelHeight * 1f)));
   }


   public void SideCamerasActiveChange(bool isActive)
   {
       leftCamera.SetActive(isActive);
       rightCamera.SetActive(isActive);
   }
}
