using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelectionMode : MonoBehaviour, ISelectionMode
{
    public void OnDeselect(Transform selection)
    {
        Outline outline = selection.GetComponent<Outline>();
        if(outline != null )
        {
            outline.OutlineWidth = 0;
        }
    }

    public void OnSelect(Transform selection)
    {
        Outline outline = selection.GetComponent<Outline>();
        if(outline != null)
        {
            outline.OutlineWidth = 10;
        }
    }
}
