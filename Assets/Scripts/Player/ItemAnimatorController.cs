using System.Collections.Generic;
using UnityEngine;

public class ItemAnimatorController : MonoBehaviour {

    [SerializeField] private Animator _headAnimator;
    [SerializeField] private Animator _torsoAnimator;
    [SerializeField] private Animator _legsAnimator;
    [SerializeField] private Animator _shoesAnimator;
    [Space]
    [SerializeField] private ItemEquippedChannelSO _itemEquippedChannel;

    private Dictionary<ClothingType, Animator> _animators;

    private void OnEnable() {
        _itemEquippedChannel.OnItemEquipped += EquipItem;
    }

    private void OnDisable() {
        _itemEquippedChannel.OnItemEquipped -= EquipItem;
    }


    private void Awake() {
        _animators = new Dictionary<ClothingType, Animator> {
            { ClothingType.HAT, _headAnimator },
            { ClothingType.SHIRT, _torsoAnimator },
            { ClothingType.PANTS, _legsAnimator },
            { ClothingType.SHOE, _shoesAnimator }
        };
    }


    private void EquipItem(Item item) {
        _animators[item.type].runtimeAnimatorController = item.animator;
    }
}
