using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyBallTrigger : MonoBehaviour
{
    public static bool isTrigger = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {
            if (isTrigger)
            {
                Main.OnBallReady?.Invoke();
                ball.ResetBall();
                isTrigger = false;
            }
        }
    }
}
