using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


namespace RPG.ScriptableObjects
{
    [CreateAssetMenu(fileName ="InventoryItemConfiguration", menuName = "Create New Configurations/InventoryItemConfiguration", order = 0)]
    public class InventoryItemConfiguration : ScriptableObject
    {
        [System.Serializable]
        public enum InventoryItemType
        {
            Hair = 0,
            Skin = 1,
            Shirt = 2,
            Pant = 3,
            Normal = 4,
        }

        [SerializeField] private string _itemCode;
        public string ItemCode  {   get { return _itemCode; }   }

        [SerializeField] private InventoryItemType _itemType;
        public InventoryItemType ItemType { get { return _itemType; } }


        [SerializeField] private Sprite _spriteItem;
        public Sprite SpriteItem { get { return _spriteItem; } }


        [SerializeField] private string _nameItem;
        public string NameItem { get { return _nameItem; } }

        [SerializeField] private SpriteLibraryAsset _skin;
        public SpriteLibraryAsset Skin { get { return _skin; } }


        public bool IsEquipment()
        {
            return _itemType != InventoryItemType.Normal;
        }
    }
}

