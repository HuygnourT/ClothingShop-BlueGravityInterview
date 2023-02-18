using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Gameplay
{
    public class NPCShopController : NPCController
    {
        [SerializeField] private ItemInShop _itemInShop;

        public ItemInShop ItemInShop { get { return _itemInShop; } }
    }
}