using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeLeft = 0f;

    private void Start()
    {
        Main.OnStopGame += StopTimer;
    }

    private void OnDisable()
    {
        Main.OnStopGame -= StopTimer;
    }

    private IEnumerator WaitStartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            Main.OnChangeValueTime?.Invoke(_timeLeft);
            yield return null;
        }

        Main.OnTimeEnd?.Invoke();
    }

    public void StartTimer(float time)
    {
        _timeLeft = time;
        StartCoroutine(WaitStartTimer());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }
}
