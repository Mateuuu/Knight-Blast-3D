using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float arrowLifetime = 2f;
    [SerializeField] private float arrowSpeed = 5f;
    private float arrowTimer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        rb.AddForce(-transform.right * arrowSpeed ,ForceMode.Impulse);
    }
    private void OnDisable()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
    private void Update()
    {
        arrowTimer += Time.deltaTime;
        if(arrowTimer >= arrowLifetime)
        {
            ObjectPool.ReturnToPool("Arrow", this.gameObject);
            arrowTimer = 0f;
        }
    }
}
