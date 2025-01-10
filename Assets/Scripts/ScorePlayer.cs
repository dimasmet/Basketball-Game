using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlayer
{
    private int _scoreValue;

    public void ResetScoreValue()
    {
        _scoreValue = 0;
    }

    public void AddScore()
    {
        _scoreValue += 10;
    }

    public int GetValueScore()
    {
        return _scoreValue;
    }
}
