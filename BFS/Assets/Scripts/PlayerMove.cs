using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMove : AIMove
{
    void Start()
    {
        Init();
    }
    void Update()
    {
        if (!isMoving)
        {
            FindSelectableTIles();
            CheckMouse();
        }
        else
        {
        }

    }

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();
                    if (t.isSelectable)
                    {
                        t.isTarget = true;
                        isMoving = true;
                    }
                }
            }
        }
    }
}
