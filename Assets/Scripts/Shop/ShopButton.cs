using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _textButton;
    [SerializeField] private Text _priceText;
    [SerializeField] private Image _ballImage;

    private BallShop ballShop;
    private ShopControll _shopControll;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            _shopControll.ChoiceBall(ballShop.numberBall);
        });
    }

    public void InitShopButton(BallShop ballShop, ShopControll shopControll, Sprite sprite)
    {
        _ballImage.sprite = sprite;
        _shopControll = shopControll;
        this.ballShop = ballShop;
        _priceText.text = this.ballShop.priceValue.ToString();
        ViewUpdate();
    }

    public void ViewUpdate()
    {
        switch (ballShop.status)
        {
            case BallShop.Status.Close:
                _priceText.gameObject.SetActive(true);
                _textButton.text = "BUY";
                break;
            case BallShop.Status.Open:
                _priceText.gameObject.SetActive(false);
                _textButton.text = "TAKE THE BALL";
                break;
            case BallShop.Status.Active:
                _priceText.gameObject.SetActive(false);
                _textButton.text = "ACTIVE";
                break;
        }
    }
}
