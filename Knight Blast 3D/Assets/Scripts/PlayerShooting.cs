using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float refireRate = .01f;
    private float fireTimer = 0;
    [SerializeField] private GameObject thingy;
    private void Start() {
        ObjectPool.NewPool("thingy", thingy);
    }
    private void Update() {
        fireTimer += Time.deltaTime;
        if(fireTimer >= refireRate)
        {
            fireTimer = 0;
            ObjectPool.SpawnFromPool("thingy", new Vector3(1, 5, 1), Quaternion.identity);
        }
    }
}
