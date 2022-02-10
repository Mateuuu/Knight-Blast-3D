using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private int arrowLifetime = 2;
    [SerializeField] private float arrowSpeed = 5f;
    Vector3 inverseVelocity = new Vector3 (-1, 1, -1);
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        StartCoroutine(ArrowTimer());
        rb.AddForce(transform.forward * arrowSpeed ,ForceMode.Impulse);
    }
    private void OnDisable()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
    IEnumerator ArrowTimer()
    {
        yield return WaitForXSeconds.WaitForXSecond[arrowLifetime];
        gameObject.layer = 6;
        ObjectPool.ReturnToPool("Arrow", this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            rb.velocity = new Vector3(-2*rb.velocity.x, rb.velocity.y, -2*rb.velocity.z);
            gameObject.layer = 9;
        }
        else if(other.gameObject.layer == 10)
        {
            StopCoroutine(ArrowTimer());
            ObjectPool.ReturnToPool("Arrow", this.gameObject);
        }
    }
}
