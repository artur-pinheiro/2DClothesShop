using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour {

    [SerializeField] private RectTransform _parentContent;
    [SerializeField] private GameObject _itemButtonPrefab;
    [SerializeField] private ItemDisplayChannelSO _itemDisplayChannel;


    #region UNITY_FUNCTIONS

    private void OnEnable() {
        _itemDisplayChannel.OnDisplayItems += DisplayItems;
    }

    private void OnDisable() {
        _itemDisplayChannel.OnDisplayItems -= DisplayItems;
        _parentContent.GetComponentsInChildren<RectTransform>().ToList().ForEach(x => Destroy(x.gameObject));
    }
    #endregion

    #region PRIVATE_METHODS

    #endregion

    #region PUBLIC_METHODS
    public void DisplayItems(List<Item> itemsList, TransactionType transaction) {
        for (int i = 0; i < itemsList.Count; i++) {
            GameObject item = Instantiate(_itemButtonPrefab, _parentContent);
            ItemButton itemButton = item.GetComponent<ItemButton>();
            itemButton.Setup(itemsList[i], transaction);
        }
    }
    #endregion
}
