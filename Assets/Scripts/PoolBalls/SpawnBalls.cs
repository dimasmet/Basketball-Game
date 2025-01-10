using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    [SerializeField] private List<Ball> _listBalls;
    [SerializeField] private Ball _prefabBall;

    private List<Ball> _tempListAllBalls = new List<Ball>();

    private void Start()
    {
        Main.OnStopGame += CloseAllBalls;
    }

    private void OnDisable()
    {
        Main.OnStopGame -= CloseAllBalls;
    }

    public Ball GetBall()
    {
        Ball ball;
        if (_listBalls.Count > 0)
        {
            ball = _listBalls[0];
            _listBalls.Remove(ball);
        }
        else
        {
            ball = Instantiate(_prefabBall);
            ball.InitBall(this);
            _tempListAllBalls.Add(ball);
        }

        ball.gameObject.SetActive(true);

        return ball;
    }

    public void ReturnBall(Ball ball)
    {
        if (_listBalls.Contains(ball) == false)
        {
            _listBalls.Add(ball);
            ball.gameObject.SetActive(false);
        }
    }

    private void CloseAllBalls()
    {
        for (int i = 0; i < _tempListAllBalls.Count; i++)
        {
            _tempListAllBalls[i].ReturnBallToPool();
        }
    }
}
