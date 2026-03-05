using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Vector3 dir = Vector3.zero;
    private float deathTime = 3f;
    private void Start()
    {
        Destroy(gameObject, deathTime);
    }

    public void SetDirection(bool isRight)
    {
        dir = isRight ? Vector3.right : Vector3.left;
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyScript>(out var enemy))
        {
            enemy.SetDamage(10f);
            Debug.Log("I here");
        }
        Destroy(gameObject);
    }


}