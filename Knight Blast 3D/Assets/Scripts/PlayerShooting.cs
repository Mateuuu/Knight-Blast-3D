using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private void Start() {
        ObjectPool.NewPool("PlayerArrow", arrow);
    }
    private void Update() {

        if(Input.GetButtonDown("Right"))
        {
            ObjectPool.SpawnFromPool("PlayerArrow", new Vector3(1, 5, 1), Quaternion.Euler(0, 0, 0));
        }
        else if(Input.GetButtonDown("Left"))
        {
            ObjectPool.SpawnFromPool("PlayerArrow", new Vector3(1, 5, 1), Quaternion.Euler(0, 180, 0));
        }
        else if(Input.GetButtonDown("Up"))
        {
            ObjectPool.SpawnFromPool("PlayerArrow", new Vector3(1, 5, 1), Quaternion.Euler(0, 90, 0));
        }
        else if(Input.GetButtonDown("Down"))
        {
            ObjectPool.SpawnFromPool("PlayerArrow", new Vector3(1, 5, 1), Quaternion.Euler(0, 270, 0));
        }
    }
}
