using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowBehavior : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float arrowLifetime = 2f;
    private float arrowTimer;
    [SerializeField] private float arrowSpeed = 5f;
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
            ObjectPool.ReturnToPool("PlayerArrow", this.gameObject);
            arrowTimer = 0f;
        }
    }
}
