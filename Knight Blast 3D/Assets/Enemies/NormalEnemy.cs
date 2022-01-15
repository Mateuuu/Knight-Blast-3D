using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : BaseEnemyBehavior
{

    [SerializeField] GameObject arrowPrefab;
    private void Start() {
        ObjectPool.NewPool("Arrow", arrowPrefab);
    }
    // Basically a start method due to object pooling.
    private void OnEnable()
    {
        TargetPlayer();
        StartCoroutine(arrowLoop());
    }
    private void OnDisable()
    {
        StopCoroutine(arrowLoop());
    }
    public override void Action()
    {
        ObjectPool.SpawnFromPool("Arrow", transform.position, transform.rotation);
    }
    public override void TakeDamage()
    {
        
    }
    private IEnumerator arrowLoop()
    {
        WaitForSeconds burstTimeWait = new WaitForSeconds(timeBetweenBurst);
        while(true)
        {
            int time = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
            yield return new WaitForSeconds(time);
            for(int i = 0; i < burst; i++)
            {
                yield return burstTimeWait;
                Action();
            }
        }
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
