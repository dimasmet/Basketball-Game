using UnityEngine;

[System.Serializable]
public class WrapShop
{
    public BallShop[] ballShops;
}

[System.Serializable]
public class BallShop
{
    public int numberBall;
    public int priceValue;
    public Status status;

    public enum Status
    {
        Close,
        Open,
        Active,
    }
}

public class ShopControll : MonoBehaviour
{
    public WrapShop wrapShop;

    public Sprite[] _ballsSprites;

    [SerializeField] private ShopButton[] shopButtons;

    private int currentBallNumber;

    private void Start()
    {
        string str = PlayerPrefs.GetString("ShopDataSav");
        if (str != "")
        {
            wrapShop = JsonUtility.FromJson<WrapShop>(str);
        }

        for (int i = 0; i < shopButtons.Length; i++)
        {
            shopButtons[i].InitShopButton(wrapShop.ballShops[i], this, _ballsSprites[i]);

            if (wrapShop.ballShops[i].status == BallShop.Status.Active)
            {
                currentBallNumber = i;

                ActiveOtherBall(currentBallNumber);
            }
        }
    }

    public void ChoiceBall(int numberBall)
    {
        switch (wrapShop.ballShops[numberBall].status)
        {
            case BallShop.Status.Open:
                ActiveOtherBall(numberBall);
                break;
            case BallShop.Status.Close:
                if (wrapShop.ballShops[numberBall].priceValue <= Main.Instance.GetValueBalance())
                {
                    Main.Instance.DissBalance(wrapShop.ballShops[numberBall].priceValue);
                    ActiveOtherBall(numberBall);
                }
                else
                {
                    Debug.Log("Ballance null");
                }
                break;
            case BallShop.Status.Active:
                break;
        }
    }

    private void ActiveOtherBall(int number)
    {
        wrapShop.ballShops[currentBallNumber].status = BallShop.Status.Open;
        shopButtons[currentBallNumber].ViewUpdate();

        currentBallNumber = number;

        wrapShop.ballShops[currentBallNumber].status = BallShop.Status.Active;
        shopButtons[currentBallNumber].ViewUpdate();

        PlayerPrefs.SetString("ShopDataSav", JsonUtility.ToJson(wrapShop));

        Main.Instance.SetChoiceBallSprite(_ballsSprites[currentBallNumber]);
    }
}
