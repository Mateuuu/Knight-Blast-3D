using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyJim : BaseEnemyBehavior
{
    private float lastTimeSinceShot = 0;
    // Basically a start method due to object pooling.
    private void OnEnable()
    {
        TargetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        lastTimeSinceShot += Time.deltaTime;
        if(lastTimeSinceShot > minTimeBetweenShots)
        {
            return;
        }
    }
    public override void Action()
    {

    }
    public override void TakeDamage()
    {
        
    }
    private void TargetPlayer()
    {
        // Vector3 target = new Vector3(0, 0, 0);
        // transform.LookAt(new Vector3(target.x, 0, target.z));
        Vector3 lookPos = new Vector3(0, 0, 0) - transform.position;
        lookPos.y = 0f;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10);

        // Vector3 lookDir = -transform.position;
        // float angle = Mathf.Atan2(lookDir.z, lookDir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
