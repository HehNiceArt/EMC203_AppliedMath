using UnityEngine;

internal interface ISelectionMode
{
    void OnSelect(Transform selection);
    void OnDeselect(Transform selection);
}
