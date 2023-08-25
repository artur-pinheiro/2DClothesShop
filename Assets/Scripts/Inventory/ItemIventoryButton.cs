using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemIventoryButton : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _equipText;
    [SerializeField] private Image _itemIcon;
    [Space]
    [SerializeField] private ItemEquippedChannelSO _itemEquippedChannel;

    private Item _item;
    private Button _button;

    private void OnDisable() {
        _itemEquippedChannel.OnItemEquipped -= CheckEquip;
        Destroy(gameObject);
    }

    private void CheckEquip(Item item) {

        if ( item.name.Equals(_item.name) ) {
            _equipText.text = "Equipped";
        } else {
            if ( item.type.Equals(_item.type) ) {
                _equipText.text = "";
            }                
        }
    }

    public void Setup(Item item) {
        _item = item;
        _itemName.text = _item.itemName;
        _equipText.text = item.isEquipped ? "Equipped" : "";
        _itemIcon.sprite = _item.icon;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => _itemEquippedChannel.RaiseItemEquipped(_item));
        _itemEquippedChannel.OnItemEquipped += CheckEquip;
    }

    public void Select() {
        if( _button != null)
            _button.Select();
    }
}
