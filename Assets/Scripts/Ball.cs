using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rbBall;
    [SerializeField] private SpriteRenderer _ballSprite;

    private SpawnBalls spawnMain;

    public void InitBall(SpawnBalls spawn)
    {
        spawnMain = spawn;
    }

    public void RunBall(Vector2 direction, float forceBall = 1)
    {
        _rbBall.AddForce(direction * forceBall, ForceMode2D.Impulse);
    }

    public void ReturnBallToPool()
    {
        spawnMain.ReturnBall(this);
        isScaleChange = false;

        _rbBall.velocity = Vector2.zero;
    }

    public void SpawnBall(Vector2 postion, Sprite sprite)
    {
        _ballSprite.sprite = sprite;
        transform.localScale = sourceScale;
        _rbBall.velocity = Vector2.zero;
        transform.position = postion;
        _rbBall.isKinematic = false;
        _rbBall.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
    }

    [SerializeField] private Vector3 sourcePos;
    [SerializeField] private Vector3 sourceScale;

    private Vector3 startPos;
    private float startTime;
    private float power;

    public bool isCircleNigh;
    private bool isScaleChange;
    private bool isTarget;

    private bool _readyToMove = false;
    public bool isRun = false;
    public bool isEndBall = false;

    public void ResetBall()
    {
        _rbBall.velocity = Vector2.zero;
        transform.position = sourcePos;
        transform.localScale = sourceScale;
        _ballSprite.sortingOrder = 4;
        isCircleNigh = false;
        isScaleChange = false;
        isTarget = false;
        _readyToMove = true;
        isRun = false;
        isEndBall = false;
        _rbBall.isKinematic = true;
        _rbBall.angularVelocity = 0;
        _rbBall.velocity = Vector2.zero;
        //_rbBall.isKinematic = false;
    }

    private void OnMouseDown()
    {
        if (_readyToMove)
        {
            startPos = Input.GetTouch(0).position;
            startTime = Time.time;

            isTarget = true;

            _rbBall.isKinematic = false;
        }
    }

    void Update()
    {
        if (isTarget)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Ended:
                        Vector3 endPos = Input.mousePosition;
                        float endTime = Time.time;

                        startPos.z = 0.1f;
                        endPos.z = 0.1f;

                        startPos = Camera.main.ScreenToWorldPoint(startPos);
                        endPos = Camera.main.ScreenToWorldPoint(endPos);

                        float duration = endTime - startTime;

                        Vector3 dir = endPos - startPos;

                        float distance = dir.magnitude;

                        power = distance / duration;

                        power = power / 2f;

                        power = Mathf.Clamp(power, 7, 12);

                        RunBall(dir.normalized, power);

                        isTarget = false;
                        break;
                }
            }
        }

        if (isCircleNigh == false)
        {
            if (transform.position.y > 2f)
            {
                isCircleNigh = true;
                _readyToMove = false;

                _ballSprite.sortingOrder = 2;

                Main.OnOpportunityHit?.Invoke();
            }
            else
            {
                if (isRun == false)
                {
                    if (transform.position.y > -1.3f)
                    {
                        isRun = true;

                        isScaleChange = true;

                        _readyToMove = false;

                        Main.OnReturnSet?.Invoke();
                    }
                }
            }
        }
        ScaleChange();
    }

    private void ScaleChange()
    {
        if (isScaleChange)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(0.26f, 0.26f, 1), Time.deltaTime * (power / 20));
        }
    }
}
