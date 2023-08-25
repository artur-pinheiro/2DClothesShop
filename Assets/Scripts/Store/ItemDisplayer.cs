using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour {

    public RectTransform _parentContent;
    [SerializeField] private TextMeshProUGUI _moneyText;
    public GameObject _itemButtonPrefab;
    [SerializeField] private ItemDisplayChannelSO _itemDisplayChannel;


    private void OnEnable() {
        _itemDisplayChannel.OnDisplayItems += DisplayItems;
        _itemDisplayChannel.OnDisplayMoney += DisplayMoney;
    }

    private void OnDisable() {
        _itemDisplayChannel.OnDisplayItems -= DisplayItems;
        _itemDisplayChannel.OnDisplayMoney -= DisplayMoney;
    }

    private void DisplayMoney(float value) {
        if (_moneyText != null) {
            _moneyText.text = value.ToString();
        }
    }

    public virtual void DisplayItems(List<Item> itemsList, TransactionType transaction) {
        for ( int i = 0; i < itemsList.Count; i++ ) {
            GameObject item = Instantiate(_itemButtonPrefab, _parentContent);
            ItemButton itemButton = item.GetComponent<ItemButton>();
            itemButton.Setup(itemsList[i], transaction);
            if (i == 0) {
                itemButton.Select();
            }
        }
    }
}
