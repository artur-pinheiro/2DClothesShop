using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour {

    [SerializeField] private RectTransform _parentContent;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private GameObject _itemButtonPrefab;
    [SerializeField] private ItemDisplayChannelSO _itemDisplayChannel;

    //private List<GameObject> _itemButtons;


    #region UNITY_FUNCTIONS

    private void OnEnable() {
        _itemDisplayChannel.OnDisplayItems += DisplayItems;
        _itemDisplayChannel.OnDisplayMoney += DisplayMoney;
    }

    private void OnDisable() {
        _itemDisplayChannel.OnDisplayItems -= DisplayItems;
        _itemDisplayChannel.OnDisplayMoney -= DisplayMoney;


        //_parentContent.GetComponentsInChildren<RectTransform>().ToList().ForEach(x => Destroy(x.gameObject));
    }
    #endregion

    #region PRIVATE_METHODS
    private void DisplayMoney(float value) {
        if (_moneyText != null) {
            _moneyText.text = value.ToString();
        }
    }

    private void DisplayItems(List<Item> itemsList, TransactionType transaction) {
        for ( int i = 0; i < itemsList.Count; i++ ) {
            GameObject item = Instantiate(_itemButtonPrefab, _parentContent);
            ItemButton itemButton = item.GetComponent<ItemButton>();
            itemButton.Setup(itemsList[i], transaction);
            if (i == 0) {
                itemButton.Select();
            }
        }
    }
    #endregion

    #region PUBLIC_METHODS

    #endregion
}
