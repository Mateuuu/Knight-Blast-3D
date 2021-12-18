using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        rb.AddForce(transform.forward ,ForceMode.Impulse);
    }
    private void OnDisable()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
}
