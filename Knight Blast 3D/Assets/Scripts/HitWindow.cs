using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWindow : MonoBehaviour
{
    [HideInInspector] public bool inHitbox = false;
    [HideInInspector] public Collider collision;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            inHitbox = true;
        }
        else
        {
            inHitbox = false;
        }
    }
}
