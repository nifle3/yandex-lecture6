using UnityEngine;
using UnityEngine.UI;

// Скрипт для кнопки увеличивающей доход с одного клика
public class ShopButton : MonoBehaviour
{

    [SerializeField] private Button _button;
    [SerializeField] private Resources _resources;
    [SerializeField] private int _price;
    [SerializeField] private Clickable _сlickable;
    [SerializeField] private Coin3D _coind3d;

    private void Start()
    {
        _button.onClick.AddListener(Buy);
    }

    private void UpdateButtonState(int coins) {
        _button.interactable = coins >= _price;
    }

    public void Buy() {
        if (_resources.TryBuy(_price)) {
            _coind3d.AddCoinsPerClick(1);
        }
    }

    private void OnEnable()
    {
        _resources.OnChangeCoins += UpdateButtonState;
    }

    private void OnDisable()
    {
        _resources.OnChangeCoins -= UpdateButtonState;
    }

}
