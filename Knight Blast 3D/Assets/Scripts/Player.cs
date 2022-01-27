using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    // Hit Windows has a variable called "inHitbox" if this is true, that means that the arrows can be blocked by the shield
    [SerializeField] private HitWindow[] hitWindows;
    [SerializeField] private GameObject shield;
    private void Awake()
    {
        ObjectPool.NewPool("Arrow", arrowPrefab);
    }

    // ! This is probably bad, and I should probably fix it, but for now, sucks to be me
    void Update()
    {
        if(hitWindows[0].inHitbox && Input.GetKeyDown(KeyCode.Y))
        {
            shield.transform.position = new Vector3(1, 1, .5f);
        }
        if(hitWindows[1].inHitbox && Input.GetKeyDown(KeyCode.T))
        {
            shield.transform.position = new Vector3(-1, 1, .5f);
        }
        if(hitWindows[2].inHitbox && Input.GetKeyDown(KeyCode.G))
        {
            shield.transform.position = new Vector3(-1, 1, -.5f);
        }
        if(hitWindows[3].inHitbox && Input.GetKeyDown(KeyCode.H))
        {
            shield.transform.position = new Vector3(1, 1, -.5f);
        }

    }
}
