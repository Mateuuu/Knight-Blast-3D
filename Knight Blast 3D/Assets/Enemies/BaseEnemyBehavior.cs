using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyBehavior : MonoBehaviour
{
    [SerializeField] public float maxTimeBetweenShots = 3f;
    [SerializeField] public float minTimeBetweenShots = 1f;
    [SerializeField] public int burst = 1;
    [SerializeField] public int health;
    private int timeElapsedSinceLastShot = 0;
    public abstract void Action();
    public abstract void TakeDamage();
}
