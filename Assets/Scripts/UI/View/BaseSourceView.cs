using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseSourceView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _sourceText;
    public virtual void SetSourceText(int current, int max = 0)
    {
        
    }
}
