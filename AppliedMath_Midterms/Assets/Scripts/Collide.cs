using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Items")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("collide!");
        }
    }
}
