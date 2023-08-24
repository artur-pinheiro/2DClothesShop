using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemDisplayChannel", menuName = "ScriptableObjects/Channels/Item Display")]
public class ItemDisplayChannelSO : ScriptableObject {

    public UnityAction<List<Item>, TransactionType> OnDisplayItems;
    public UnityAction<float> OnDisplayMoney;

    public void RaiseDiplay(List<Item> items, TransactionType transaction) {
        OnDisplayItems?.Invoke(items, transaction);
    }

    public void RaiseDisplayMoney(float value) {
        OnDisplayMoney?.Invoke(value);
    }
}
