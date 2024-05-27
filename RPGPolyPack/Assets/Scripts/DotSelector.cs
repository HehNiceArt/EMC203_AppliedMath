using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSelector : MonoBehaviour, ISelector
{
    [SerializeField] string selectableTag = "Selectable";
    public float threshold;
    public List<SelectableText> selectable;
    private Transform _selection;
    public void CheckRay(Ray ray)
    {
        _selection = null;
        var closest = 0f;
        for(int i = 0; i < selectable.Count; i++)
        {
            Vector3 vector1 = ray.direction;
            Vector3 vector2 = selectable[i].transform.position - ray.origin;
            float lookPercent = Vector3.Dot(vector1.normalized, vector2.normalized);

            selectable[i].lookPercent = lookPercent;
            if(lookPercent > threshold && lookPercent > closest)
            {
                closest = lookPercent;
                _selection = selectable[i].transform;
            }
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }
}
