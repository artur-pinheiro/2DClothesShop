using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemPrice;
    [SerializeField] private Image _itemIcon;
    [Space]
    [SerializeField] private ItemPurchaseChannelSO _itemPurchaseChannel;
    [SerializeField] private PlayAudioChannelSO _playAudioChannel;

    private Item _item;
    private Button _button;
    private TransactionType _transactionType;

    private void OnDisable() {
        Destroy(gameObject);
    }

    private void DisableButton() {
        _button.interactable = false;
    }

    public void Setup(Item item, TransactionType transaction) {
        _item = item;
        _transactionType = transaction;
        _itemName.text = _item.itemName;
        _itemPrice.text = _item.price.ToString();
        _itemIcon.sprite = _item.icon;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => _itemPurchaseChannel.RaisePurchase(_item, _transactionType));
        _button.onClick.AddListener(() => _playAudioChannel.RaisePlaySound("COIN"));
        _button.onClick.AddListener(() => DisableButton());
        _button.onClick.AddListener(() => Destroy(gameObject,0.5f));
    }

    public void Select() {
        if( _button != null)
            _button.Select();
    }
}
