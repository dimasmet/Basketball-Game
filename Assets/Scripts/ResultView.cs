using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [SerializeField] private Button _homeBtn;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _recordTop;
    [SerializeField] private Text _addValueBalanceText;

    [SerializeField] private GameObject _panel;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _homeBtn.onClick.AddListener(() =>
        {
            _animator.Play("idle");
            _panel.SetActive(false);

            ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Menu);
        });
        _restartBtn.onClick.AddListener(() =>
        {
            _animator.Play("idle");
            _panel.SetActive(false);

            Main.Instance.StartGame(TypeGame.Classic);
        });
    }

    public void ShowResult(int score, int balanceAdd, bool isRecord = false)
    {
        _panel.SetActive(true);
        _animator.Play("Show");

        if (isRecord)
        {
            _recordTop.SetActive(true);
        }
        else
        {
            _recordTop.SetActive(false);
        }

        _scoreText.text = score.ToString();

        _addValueBalanceText.text = "+" + balanceAdd + " balance";

        GameSound.OnPlaySound?.Invoke(SName.Result);
    }
}
