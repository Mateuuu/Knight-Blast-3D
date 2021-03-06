using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    // Hit Windows has a variable called "inHitbox" if this is true, that means that the arrows can be blocked by the shield
    [SerializeField] private HitWindow[] hitWindows;
    [SerializeField] private GameObject shield;


    Vector3 topRight = new Vector3(1, 1, .5f);
    Vector3 topLeft = new Vector3(-1, 1, .5f);
    Vector3 bottomLeft = new Vector3(-1, 1, -.5f);
    Vector3 bottomRight = new Vector3(1, 1, -.5f);


    private void Awake()
    {
        ObjectPool.NewPool("Arrow", arrowPrefab);
    }

    // ! This is probably bad, and I should probably fix it, but for now, sucks to be me
    void Update()
    {
        shield.gameObject.layer = 10;
        if(Input.GetKeyDown(KeyCode.Y))
        {
            shield.transform.position = topRight;
            if(hitWindows[0].inHitbox)
            {
                shield.gameObject.layer = 8;
            }
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            shield.transform.position = topLeft;
            if(hitWindows[1].inHitbox)
            {
                shield.gameObject.layer = 8;
            }
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            shield.transform.position = bottomLeft;
            if(hitWindows[2].inHitbox)
            {
                shield.gameObject.layer = 8;
            }
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            shield.transform.position = bottomRight;
            if(hitWindows[3].inHitbox)
            {
                shield.gameObject.layer = 8;
            }
        }
    }
}
