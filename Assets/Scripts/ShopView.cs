using UnityEngine;
using UnityEngine.UI;

public class ShopView : Screen
{
    [SerializeField] private Button _backBtn;

    private void Awake()
    {
        _backBtn.onClick.AddListener(() =>
        {
            ControlScreens.Instance.ShowScreen(ControlScreens.ScreenType.Menu);
        });
    }
}
