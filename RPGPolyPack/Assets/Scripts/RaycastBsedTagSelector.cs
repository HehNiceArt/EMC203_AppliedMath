using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBsedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] string selectableTag = "Selectable";
    private Transform _selection;
    public void CheckRay(Ray ray)
    {
        _selection = null;
        if(!Physics.Raycast(ray, out var hitInfo)) return;

        var selection = hitInfo.transform;
        if(selection.CompareTag(selectableTag))
        {
            _selection = selection;
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }
}
