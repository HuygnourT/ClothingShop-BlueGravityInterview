using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Gameplay
{
    [System.Serializable]
    public struct ItemShop
    {
        public string _itemCode;
        public int _priceForBuy;
        public int _priceForSell;
    }

    [System.Serializable]
    public struct ItemInShop
    {
        public int _priceDefaultForSell;
        public List<ItemShop> _itemShops;
    }
}