using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NpcMobale : EnemyScript
{
    [SerializeField] private Transform botCheckTransform;
    [SerializeField] private float botCheckRadius;
    [SerializeField] private Transform frontCheckTransform;
    [SerializeField] private float frontCheckRadius;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;
    private bool hasFront;
    private bool hasBot;
    private bool isLeft;

    private void Update()
    {
        CheckBot();
        CheckFront();
        Movement();
    }
    private void CheckBot()
    {
        hasBot = Physics2D.OverlapCircle(botCheckTransform.position, botCheckRadius);
    }
    private void CheckFront()
    {
        hasFront = Physics2D.OverlapCircle(frontCheckTransform.position, frontCheckRadius);
    }

    private void Movement()
    {
        //float x = (hasBot && !hasFront) ? 1 : 0;
        if (hasBot && !hasFront)
        {
            float mod = isLeft ? -1 : 1;
            rb.velocity = new Vector2(mod * speed, rb.velocity.y);
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            isLeft = !isLeft;
        }
    }
    private void OnDrawGizmos()
    {
        if (botCheckTransform != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(botCheckTransform.position, botCheckRadius);

        }
        if (frontCheckTransform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(frontCheckTransform.position, frontCheckRadius);
        }

    }
}
