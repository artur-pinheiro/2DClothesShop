using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryDisplayer : ItemDisplayer {

    public override void DisplayItems(List<Item> itemsList, TransactionType transaction) {
        for ( int i = 0; i < itemsList.Count; i++ ) {
            GameObject item = Instantiate(_itemButtonPrefab, _parentContent);
            ItemIventoryButton itemButton = item.GetComponent<ItemIventoryButton>();
            itemButton.Setup(itemsList[i]);
            if ( i == 0 ) {
                itemButton.Select();
            }
        }
    }
}
