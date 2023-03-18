using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulationView : BaseSourceView
{
    public override void SetSourceText(int current, int max)
    {
        _sourceText.text = current + "/" + max;
    }
}
