using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingyBehavior : MonoBehaviour
{
    [SerializeField] private float lifetime = 4f;
    private float timer = 0;
    private void Update()
    {
        transform.position += new Vector3(0, .1f, 0);
        timer += Time.deltaTime;
        if(timer >= lifetime)
        {
            timer = 0;
            ObjectPool.ReturnToPool("thingy", this.gameObject);
        }
    }
}
