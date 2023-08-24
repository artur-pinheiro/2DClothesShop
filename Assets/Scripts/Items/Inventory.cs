using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [Tooltip("The type of transaction that will cause an item to be added to this inventory")]
    public TransactionType _buyingTransactionType;
    [Tooltip("The type of transaction that will cause an item to be removed from this inventory")]
    public TransactionType _sellingTransactionType;
    public List<Item> _itemsList;
    [Space]
    public ItemPurchaseChannelSO _itemPurchaseChannel;
    public ItemDisplayChannelSO _itemDisplayChannel;

    private void OnEnable() {
        _itemPurchaseChannel.OnItemPurchased += UpdateInventory;
    }
    private void OnDisable() {
        _itemPurchaseChannel.OnItemPurchased -= UpdateInventory;
    }

    public virtual void UpdateInventory(Item item, TransactionType transaction) {
        if (transaction == _buyingTransactionType) {
            _itemsList.Add(item);
        } else {
            if ( _itemsList.Contains(item) ) {
                _itemsList.Remove(item);
            }
        }
    }

    public virtual void DisplayItemsForSell() {
        _itemDisplayChannel.RaiseDiplay(_itemsList, _sellingTransactionType);
    }
}
