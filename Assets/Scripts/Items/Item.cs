using UnityEngine;

public enum ClothingType{
    HAT,
    SHIRT,
    GLOVE,
    SHOE
}

[CreateAssetMenu(fileName = "new Item", menuName = "ScriptableObjects/Items/Item")]
public class Item : ScriptableObject {
    public ClothingType type;
    public string itemName;
    public float price;
    public Sprite icon;
}
