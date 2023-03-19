using TMPro;
using UnityEngine;

namespace UI.View
{
    public class BaseSourceView : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _sourceText;
        public virtual void SetSourceText(int current, int max = 0)
        {
        
        }
    }
}
