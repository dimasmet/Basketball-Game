using UnityEngine;

public class ControlScreens : MonoBehaviour
{
    public static ControlScreens Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        ShowScreen(ScreenType.Menu);
    }

    [SerializeField] private Screen _menu;
    [SerializeField] private Screen _game;
    [SerializeField] private Screen _settings;
    [SerializeField] private Screen _shop;

    private Screen _current;

    public enum ScreenType
    {
        Menu,
        Game,
        Settings,
        Shop
    }

    public void ShowScreen(ScreenType type)
    {
        if (_current != null) _current.Hide();

        switch (type)
        {
            case ScreenType.Menu:
                _current = _menu;
                break;
            case ScreenType.Game:
                _current = _game;
                break;
            case ScreenType.Settings:
                _current = _settings;
                break;
            case ScreenType.Shop:
                _current = _shop;
                break;
        }
        _current.Show();
    }
}
