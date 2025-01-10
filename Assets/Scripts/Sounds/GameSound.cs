using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SName
{
    SuccessHit,
    KickBall,
    Click,
    Result
}

public class GameSound : MonoBehaviour
{
    public static Action<SName> OnPlaySound;
    public static Action OnPlayVibro;
    public static Func<bool> OnChangeStatus;
    public static Func<bool> OnChangeStatusVibro;

    [SerializeField] private AudioSource _backSound;
    [SerializeField] private AudioSource _soundSource;

    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _kickball;
    [SerializeField] private AudioClip _successHit;
    [SerializeField] private AudioClip _result;

    private bool actSounds = true;
    private bool actVibro = true;

    private bool ChangeActive()
    {
        actSounds = !actSounds;

        if (actSounds) _backSound.Play();
        else _backSound.Stop();

        return actSounds;
    }

    private bool ChangeActiveVibro()
    {
        actVibro = !actVibro;

        return actVibro;
    }

    private void Start()
    {
        OnPlayVibro += PlayVibro;
        OnPlaySound += PlayShotSound;
        OnChangeStatus += ChangeActive;
        OnChangeStatusVibro += ChangeActiveVibro;
    }

    private void OnDisable()
    {
        OnPlayVibro -= PlayVibro;
        OnPlaySound -= PlayShotSound;
        OnChangeStatus -= ChangeActive;
        OnChangeStatusVibro -= ChangeActiveVibro;
    }

    private void PlayShotSound(SName sName)
    {
        if (actSounds)
        {
            switch (sName)
            {
                case SName.SuccessHit:
                    _soundSource.PlayOneShot(_successHit);
                    break;
                case SName.KickBall:
                    _soundSource.PlayOneShot(_kickball);
                    break;
                case SName.Click:
                    _soundSource.PlayOneShot(_click);
                    break;
                case SName.Result:
                    _soundSource.PlayOneShot(_result);
                    break;
            }
        }
    }

    private void PlayVibro()
    {
        if (actVibro)
        {
            Vibration.VibratePop();
            Debug.Log("Vibro");
        }
    }
}
