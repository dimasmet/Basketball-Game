using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.iOS;

public class ViewSettings : Screen
{
    [SerializeField] private Button _backBtn;
    [SerializeField] private Text _titleTextView;

    private void Awake()
    {
        _backBtn.onClick.AddListener(() =>
        {
            ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Menu);

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });

        _privacyButton.onClick.AddListener(() =>
        {
            _viewText.SetActive(true);

            _privacy.SetActive(true);
            _terms.SetActive(false);

            _titleTextView.text = "PRIVACY POLICY";

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });

        _termsButton.onClick.AddListener(() =>
        {
            _viewText.SetActive(true);

            _privacy.SetActive(false);
            _terms.SetActive(true);

            _titleTextView.text = "TERMS OF  USE";

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });

        _rateGameButton.onClick.AddListener(() =>
        {
            Device.RequestStoreReview();
        });

        _closeViewButton.onClick.AddListener(() =>
        {
            _viewText.SetActive(false);

            GameSound.OnPlaySound?.Invoke(SName.Click);
        });

        _soundsButton.onClick.AddListener(() =>
        {
            bool st = GameSound.OnChangeStatus.Invoke();

            if (st) _soundsButton.transform.GetChild(0).GetComponent<Text>().text = "ON";
            else _soundsButton.transform.GetChild(0).GetComponent<Text>().text = "OFF";
        });

        _vibroButton.onClick.AddListener(() =>
        {
            bool st = GameSound.OnChangeStatusVibro.Invoke();

            if (st) _vibroButton.transform.GetChild(0).GetComponent<Text>().text = "ON";
            else _vibroButton.transform.GetChild(0).GetComponent<Text>().text = "OFF";
        });
    }

    [SerializeField] private Button _privacyButton;
    [SerializeField] private Button _termsButton;
    [SerializeField] private Button _rateGameButton;
    [SerializeField] private Button _soundsButton;
    [SerializeField] private Button _vibroButton;

    [Header("text view")]
    [SerializeField] private GameObject _viewText;
    [SerializeField] private Button _closeViewButton;
    [SerializeField] private GameObject _privacy;
    [SerializeField] private GameObject _terms;
}
