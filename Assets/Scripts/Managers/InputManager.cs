using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
   public static Action OnMouseDownEvent;
   public static Action OnMouseDragEvent;
   public static Action OnMouseUpEvent;

   public void MouseEnabled()
   {
      StartCoroutine("MouseSituationRoutine");
   }

   private IEnumerator MouseSituationRoutine()
   {
      while (true)
      {
         if (Input.GetMouseButtonDown(0))
            OnMouseDownEvent?.Invoke();
         if (Input.GetMouseButton(0))
            OnMouseDragEvent?.Invoke();
         if (Input.GetMouseButtonUp(0))
            OnMouseUpEvent?.Invoke();
         
         yield return null;
      }
   }
}
