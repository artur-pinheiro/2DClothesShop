using UnityEngine;
using UnityEngine.Events;

public enum TransactionType {
    PLAYER_BUYING,
    PLAYER_SELLING
}

[CreateAssetMenu(fileName = "ItemPurchaseChannel", menuName = "ScriptableObjects/Channels/Item Purchase")]
public class ItemPurchaseChannelSO : ScriptableObject {
    public UnityAction<Item, TransactionType> OnItemPurchased;

    public void RaisePurchase(Item item, TransactionType transaction) {
        OnItemPurchased?.Invoke(item, transaction);
    }
}
