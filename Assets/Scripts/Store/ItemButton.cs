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

    private Item _item;
    private Button button;
    private TransactionType _transactionType;

    public void Setup(Item item, TransactionType transaction) {
        _item = item;
        _transactionType = transaction;
        _itemName.text = _item.itemName;
        _itemPrice.text = _item.price.ToString();
        _itemIcon.sprite = _item.icon;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => _itemPurchaseChannel.RaisePurchase(_item, _transactionType));
        button.onClick.AddListener(() => Destroy(gameObject,1f));
    }
}
