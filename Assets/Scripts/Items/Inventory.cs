using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [Tooltip("The type of transaction that will cause an item to be added to this inventory")]
    [SerializeField] private TransactionType _buyingTransactionType;
    [Tooltip("The type of transaction that will cause an item to be removed from this inventory")]
    [SerializeField] private TransactionType _sellingTransactionType;
    [SerializeField] private float _currentMoney = 0f;
    [SerializeField] private List<Item> _itemsList;
    [Space]
    [SerializeField] private ItemPurchaseChannelSO _itemPurchaseChannel;
    [SerializeField] private ItemDisplayChannelSO _itemDisplayChannel;

    private void OnEnable() {
        _itemPurchaseChannel.OnItemPurchased += UpdateInventory;
    }
    private void OnDisable() {
        _itemPurchaseChannel.OnItemPurchased -= UpdateInventory;
    }

    private void UpdateInventory(Item item, TransactionType transaction) {
        if (transaction == _buyingTransactionType) {
            _itemsList.Add(item);
            _currentMoney -= item.price;
        } else {
            if ( _itemsList.Contains(item) ) {
                _itemsList.Remove(item);
                _currentMoney += item.price;
            }
        }
    }

    public void DisplayItemsForSell() {
        _itemDisplayChannel.RaiseDiplay(_itemsList, _sellingTransactionType);
    }
}
