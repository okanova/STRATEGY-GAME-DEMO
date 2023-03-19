using System;
using System.Collections;
using Extensions;
using UnityEngine;

namespace Managers
{
   public class InputManager : MonoSingleton<InputManager>
   {
      public static Action OnLeftMouseDownEvent;
      public static Action OnLeftMouseDragEvent;
      public static Action OnLeftMouseUpEvent;
   
      public static Action OnRightMouseDownEvent;
      public static Action OnRightMouseDragEvent;
      public static Action OnRightMouseUpEvent;

      public void MouseEnabled()
      {
         StartCoroutine("MouseSituationRoutine");
      }

      private IEnumerator MouseSituationRoutine()
      {
         while (true)
         {
            #region Mouse Inputs

            if (Input.GetMouseButtonDown(0))
               OnLeftMouseDownEvent?.Invoke();
            if (Input.GetMouseButton(0))
               OnLeftMouseDragEvent?.Invoke();
            if (Input.GetMouseButtonUp(0))
               OnLeftMouseUpEvent?.Invoke();
         
            if (Input.GetMouseButtonDown(1))
               OnRightMouseDownEvent?.Invoke();
            if (Input.GetMouseButton(1))
               OnRightMouseDragEvent?.Invoke();
            if (Input.GetMouseButtonUp(1))
               OnRightMouseUpEvent?.Invoke();

            #endregion
        
         
            yield return null;
         }
      }
   }
}
