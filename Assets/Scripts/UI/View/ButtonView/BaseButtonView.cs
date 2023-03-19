using UnityEngine;

namespace UI.View.ButtonView
{
   public abstract class BaseButtonView : MonoBehaviour
   {
      public void OnPointerDown()
      {
         OnButtonClick();
      }

      protected abstract void OnButtonClick();

   }
}
