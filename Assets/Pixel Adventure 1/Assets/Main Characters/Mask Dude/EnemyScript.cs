using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float hpEnemy;
    void Start()
    {
        hpEnemy = 100f;
    }
    public void SetDamage(float damage)
    {
        hpEnemy -= damage;
        if (hpEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }

}
