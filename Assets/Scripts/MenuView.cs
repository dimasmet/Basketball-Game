using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : Screen
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _traningBtn;
    [SerializeField] private Button _settingsbtn;
    [SerializeField] private Button _shopBtn;
    [SerializeField] private Button _tutorBtn;

    [SerializeField] private Animator _prev;

    [SerializeField] private TutorHand tutorHand;

    private void Start()
    {
        _prev.Play("Hide");
        Invoke(nameof(ClosePrev), 1);
    }

    private void ClosePrev()
    {
        _prev.gameObject.SetActive(false);
    }

    void Awake()
    {
        _playBtn.onClick.AddListener(() =>
        {
            if (PlayerPrefs.GetInt("ShowRulesGame") == 0)
            {
                PlayerPrefs.SetInt("ShowRulesGame", 1);
                tutorHand.Show();
            }
            else
            {
                ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Game);
                Main.Instance.StartGame(TypeGame.Classic);

                GameSound.OnPlaySound?.Invoke(SName.Click);
            }
        });

        _traningBtn.onClick.AddListener(() =>
        {
            ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Game);
            Main.Instance.StartGame(TypeGame.Training);

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });

        _settingsbtn.onClick.AddListener(() =>
        {
            ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Settings);

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });

        _shopBtn.onClick.AddListener(() =>
        {
            ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Shop);

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });

        _tutorBtn.onClick.AddListener(() =>
        {
            tutorHand.Show();
        });
    }
}
