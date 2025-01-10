using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : Screen
{
    private ViewTime _viewTime;
    private ViewScore _viewScore;

    [SerializeField] private Button _backBtn;

    [Header("Score view")]
    [SerializeField] private Text _scoreTextField;
    [SerializeField] private Animator _animScore;
    [Header("Time view")]
    [SerializeField] private Text _timeTextField;

    private void Awake()
    {
        _backBtn.onClick.AddListener(() =>
        {
            Main.OnStopGame?.Invoke();
            ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Menu);

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });
    }

    private void Start()
    {
        InitView();
    }

    private void InitView()
    {
        _viewTime = new ViewTime(_timeTextField);
        _viewScore = new ViewScore(_scoreTextField, _animScore);
    }

    public void SetViewToGame(TypeGame typeGame)
    {
        switch (typeGame)
        {
            case TypeGame.Classic:
                _scoreTextField.transform.parent.gameObject.SetActive(true);
                _timeTextField.transform.parent.gameObject.SetActive(true);
                break;
            case TypeGame.Training:
                _scoreTextField.transform.parent.gameObject.SetActive(true);
                _timeTextField.transform.parent.gameObject.SetActive(false);
                break;
        }
    }

    public void SetScoreView(int score)
    {
        string scoreString = score.ToString();
        _viewScore.SetValue(scoreString);
    }

    public void SetValueTimeView(float value)
    {
        float minutes = Mathf.FloorToInt(value / 60);
        float seconds = Mathf.FloorToInt(value % 60);
        string timeStrForm = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (value <= 0)
            timeStrForm = "00:00";
        _viewTime.SetValue(timeStrForm);
    }
}
