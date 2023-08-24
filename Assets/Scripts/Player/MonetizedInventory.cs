using UnityEngine;

public class MonetizedInventory : Inventory {
    [Space]
    [SerializeField] private float _currentMoney = 0f;

    public override void UpdateInventory(Item item, TransactionType transaction) {
        if ( transaction == _buyingTransactionType ) {
            _itemsList.Add(item);
            _currentMoney -= item.price;
        } else {
            if ( _itemsList.Contains(item) ) {
                _itemsList.Remove(item);
                _currentMoney += item.price;
            }
        }
        _itemDisplayChannel.RaiseDisplayMoney(_currentMoney);
    }

    public override void DisplayItemsForSell() {
        _itemDisplayChannel.RaiseDiplay(_itemsList, _sellingTransactionType);
        _itemDisplayChannel.RaiseDisplayMoney(_currentMoney);
    }

}
