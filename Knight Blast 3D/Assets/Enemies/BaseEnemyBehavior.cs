using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyBehavior : MonoBehaviour
{
    [SerializeField] public int maxTimeBetweenShots = 3;
    [SerializeField] public int minTimeBetweenShots = 1;
    [SerializeField] public int burst = 1;
    [Range(.1f, .5f)]
    [SerializeField] public float timeBetweenBurst;
    [SerializeField] public int health;
    public abstract void Action();
    public abstract void TakeDamage();
}
