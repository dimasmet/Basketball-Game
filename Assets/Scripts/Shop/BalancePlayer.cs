using UnityEngine;
using UnityEngine.UI;

public class BalancePlayer
{
    private int _balanceValue;
    private Text[] _balanceTextFields;

    public BalancePlayer(Text[] texts)
    {
        _balanceTextFields = texts;
        _balanceValue = PlayerPrefs.GetInt("BalancePlayer");
        UpdateViewBalance();
    }

    private void UpdateViewBalance()
    {
        for (int  i = 0; i < _balanceTextFields.Length; i++)
        {
            _balanceTextFields[i].text = _balanceValue.ToString();
        }

        PlayerPrefs.SetInt("BalancePlayer", _balanceValue);
    }

    public int GetBalanceValue()
    {
        return _balanceValue;
    }

    public void AddBalance(int valueAdd)
    {
        _balanceValue += valueAdd;
        UpdateViewBalance();
    }

    public void DiscreaseBalance(int valueDis)
    {
        _balanceValue -= valueDis;
        UpdateViewBalance();
    }
}
