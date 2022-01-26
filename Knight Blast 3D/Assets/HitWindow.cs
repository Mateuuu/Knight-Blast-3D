using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWindow : MonoBehaviour
{
    [HideInInspector] public bool inHitbox = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            inHitbox = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
    if(other.gameObject.layer == 6)
        {
            inHitbox = false;
        } 
    }
}
