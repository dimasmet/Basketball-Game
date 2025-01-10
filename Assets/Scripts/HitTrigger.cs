using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider2D;
    [SerializeField] private BoxCollider2D _leftColider;
    [SerializeField] private BoxCollider2D _rightColider;
    [SerializeField] private BoxCollider2D _leftPlatfromLimited;
    [SerializeField] private BoxCollider2D _readyTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            if (ball.isCircleNigh)
            {
                Main.OnHitSuccess?.Invoke();
                GameSound.OnPlayVibro?.Invoke();
            }
        }
    }

    private void Start()
    {
        Main.OnOpportunityHit += ActiveTriggerCheck;
        Main.OnReturnSet += DeActiveTriggerCheck;
        Main.OnBallReady += ActiveLeftLimitedWall;
    }

    private void OnDisable()
    {
        Main.OnOpportunityHit -= ActiveTriggerCheck;
        Main.OnReturnSet -= DeActiveTriggerCheck;
        Main.OnBallReady -= ActiveLeftLimitedWall;
    }

    private void ActiveTriggerCheck()
    {
        //_collider2D.enabled = true;
        _leftColider.enabled = true;
        _rightColider.enabled = true;
    }

    private void DeActiveTriggerCheck()
    {
        //_collider2D.enabled = false;
        _leftColider.enabled = false;
        _rightColider.enabled = false;
        _leftPlatfromLimited.enabled = false;
        _readyTrigger.enabled = true;
        ReadyBallTrigger.isTrigger = true;
    }

    private void ActiveLeftLimitedWall()
    {
        _leftPlatfromLimited.enabled = true;
    }
}
