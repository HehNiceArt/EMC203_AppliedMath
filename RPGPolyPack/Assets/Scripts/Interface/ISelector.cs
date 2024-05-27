using UnityEngine;

public interface ISelector
{
    void CheckRay(Ray ray);
    Transform GetSelection();
}
