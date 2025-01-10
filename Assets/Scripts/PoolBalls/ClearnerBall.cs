using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearnerBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {
            ball.ReturnBallToPool();
        }
    }
}
