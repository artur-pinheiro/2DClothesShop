using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : Inventory {

    [SerializeField] private ItemDisplayChannelSO _displayInventoryChannel;
    [SerializeField] private ItemEquippedChannelSO _itemEquippedChannel;
    [SerializeField] private InputReader _inputReader;
    [Space]
    [SerializeField] private float _currentMoney = 0f;
    [SerializeField] private Item[] _initialEquippedItems;

    [Space]
    public UnityEvent OnShowInventory;


    private Dictionary<ClothingType, Item> _equippedItems;

    private void OnEnable() {
        _itemPurchaseChannel.OnItemPurchased += UpdateInventory;
        _inputReader.InventoryEvent += ShowInventory;
        _itemEquippedChannel.OnItemEquipped += EquipItem;
    }

    private void OnDisable() {
        _itemPurchaseChannel.OnItemPurchased -= UpdateInventory;
        _inputReader.InventoryEvent -= ShowInventory;
        _itemEquippedChannel.OnItemEquipped -= EquipItem;
    }

    private void Awake() {
        _equippedItems = new Dictionary<ClothingType, Item>();
        for ( int i = 0; i < _initialEquippedItems.Length; i++ ) {
            _equippedItems.Add(_initialEquippedItems[i].type, _initialEquippedItems[i]);
            _equippedItems[_initialEquippedItems[i].type].isEquipped = true;
            _itemsList.Add(_initialEquippedItems[i]);
        }
    }

    private void OnDestroy() {
        foreach ( KeyValuePair<ClothingType, Item> item in _equippedItems ) {
            item.Value.isEquipped = false;
        }
    }

    private void ShowInventory() {
        OnShowInventory?.Invoke();
        _displayInventoryChannel.RaiseDiplay(_itemsList, _sellingTransactionType);
        _displayInventoryChannel.RaiseDisplayMoney(_currentMoney);
        _inputReader.DisableInput();
    }

    private void EquipItem(Item item) {
        if (_equippedItems.ContainsKey(item.type)) {
            _equippedItems[item.type].isEquipped = false;
            _equippedItems[item.type] = item;
            _equippedItems[item.type].isEquipped = true;
        } else {
            _equippedItems.Add(item.type, item);
            _equippedItems[item.type].isEquipped = true;
        }
    }

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
        List<Item> _availableItems = new List<Item>(_itemsList);
        foreach ( KeyValuePair<ClothingType, Item> item in _equippedItems ) {
            if(_availableItems.Contains(item.Value))
                _availableItems.Remove(item.Value);
        }

        _itemDisplayChannel.RaiseDiplay(_availableItems, _sellingTransactionType);
        _itemDisplayChannel.RaiseDisplayMoney(_currentMoney);
    }

}
