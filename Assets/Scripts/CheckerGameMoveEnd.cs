using UnityEngine;

public class CheckerGameMoveEnd : MonoBehaviour
{
    [SerializeField] private float _force;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            GameSound.OnPlaySound?.Invoke(SName.KickBall);

            if (ball.isRun == true && ball.isEndBall == false)
            {
                ball.isEndBall = true;
                if (ball.transform.position.x <= 0)
                {
                    ball.RunBall(Vector2.left * _force);
                }
                else
                {
                    ball.RunBall(Vector2.right * _force);
                }
            }
        }
    }
}
