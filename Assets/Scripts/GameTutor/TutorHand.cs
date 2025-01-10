using UnityEngine;
using UnityEngine.UI;

public class TutorHand : Screen
{
    [SerializeField] private Button _nextBtn;

    [SerializeField] private GameObject[] _panels;
    private int numberCurrent;

    private void Awake()
    {
        _nextBtn.onClick.AddListener(() =>
        {
            if (numberCurrent != _panels.Length - 1)
            {
                _panels[numberCurrent].SetActive(false);
                numberCurrent++;
                _panels[numberCurrent].SetActive(true);
            }
            else
            {
                Hide();
            }
        });
    }

    public override void Show()
    {
        base.Show();

        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }

        numberCurrent = 0;

        _panels[numberCurrent].SetActive(true);
    }
}
