using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour, IViewScreen
{
    [SerializeField] private GameObject _screen;

    public void Hide()
    {
        _screen.SetActive(false);
    }

    public virtual void Show()
    {
        _screen.SetActive(true);
    }

}
