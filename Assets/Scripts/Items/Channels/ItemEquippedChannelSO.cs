using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemEquippedChannel", menuName = "ScriptableObjects/Channels/Item Equipped")]
public class ItemEquippedChannelSO : ScriptableObject {

    public UnityAction<Item> OnItemEquipped;

    public void RaiseItemEquipped(Item item) {
        OnItemEquipped?.Invoke(item);
    }
}
