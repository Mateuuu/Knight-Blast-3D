using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    private void Start() {
    }
    private void Update()
    {
        if(Input.GetButtonDown("TopRight"))
        {
            shield.transform.position = new Vector3(1, 0, 1);
            shield.transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        if(Input.GetButtonDown("TopLeft"))
        {
            shield.transform.position = new Vector3(-1, 0, 1);
            shield.transform.rotation = Quaternion.Euler(0, 45, 0);

        }
        if(Input.GetButtonDown("BottomRight"))
        {
            shield.transform.position = new Vector3(1, 0, -1);
            shield.transform.rotation = Quaternion.Euler(0, 45, 0);

        }
        if(Input.GetButtonDown("BottomLeft"))
        {
            shield.transform.position = new Vector3(-1, 0, -1);
            shield.transform.rotation = Quaternion.Euler(0, -45, 0);

        }
    }
}
