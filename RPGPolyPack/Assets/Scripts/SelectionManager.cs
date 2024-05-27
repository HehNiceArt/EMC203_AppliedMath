using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    IRaycastProvider iRayProvider;
    ISelector iSelector;
    ISelectionMode iSelectionMode;

    private Transform currentSelecton;

    private void Awake()
    {
        iRayProvider = GetComponent<IRaycastProvider>();
        iSelector = GetComponent<ISelector>();
        iSelectionMode = GetComponent<ISelectionMode>();
    }

    private void Update()
    {
        if (currentSelecton != null)
            iSelectionMode.OnDeselect(currentSelecton);
        iSelector.CheckRay(iRayProvider.CreateRay());
        currentSelecton = iSelector.GetSelection();

        if(currentSelecton != null)
            iSelectionMode.OnSelect(currentSelecton);
    }
}
