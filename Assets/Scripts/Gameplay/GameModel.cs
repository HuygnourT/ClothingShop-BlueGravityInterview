using System;
using System.Collections.Generic;
using UnityEngine;
using RPG.UI;
using RPG.ScriptableObjects;


namespace RPG.Gameplay
{
    [System.Serializable]
    public class GameModel
    {
        public CharacterController Player;
        public InputController Input;
        public DialogUIController Dialog;
        public InventoryUIController Inventory;
        public ShopUIController Shop;
        public ItemController ItemController;

        Dictionary<string, int> intenvory = new Dictionary<string, int>();
        Dictionary<GameObject, HashSet<string>> conversations = new Dictionary<GameObject, HashSet<string>>();

        public IEnumerable<string> InventoryItems => intenvory.Keys;

        public void RegisterConversation(GameObject owner, string id)
        {
            if (!conversations.TryGetValue(owner, out HashSet<string> ids))
                conversations[owner] = ids = new HashSet<string>();
            ids.Add(id);
        }


        #region Item Controller
        public Sprite GetItemSprite(string itemCode)
        {
            var itemConfiguration = GetItem(itemCode);

            if (itemConfiguration != null)
            {
                return itemConfiguration.SpriteItem;
            }

            return null;
        }


        public InventoryItemConfiguration GetItem(string itemCode)
        {
            return ItemController.GetInventoryItemConfiguration(itemCode);
        }


        public string GetDescriptionItem(string itemCode)
        {
            var itemConfiguration = GetItem(itemCode);

            if (itemConfiguration != null)
            {
                return itemConfiguration.DescriptionItem;
            }

            return "";
        }


        public string GetNameItem(string itemCode)
        {
            var itemConfiguration = GetItem(itemCode);

            if (itemConfiguration != null)
            {
                return itemConfiguration.NameItem;
            }

            return "";
        }
        #endregion


        #region Inventory
        public int GetInventoryCount(string itemCode)
        {
            foreach (var child in intenvory)
            {
                if (child.Key == itemCode)
                {
                    return child.Value;
                }
            }

            return 0;
        }

        public void AddInventoryItem(string itemCode)
        {
            if (intenvory.ContainsKey(itemCode) == false)
            {
                intenvory.Add(itemCode, 1);
            }
            else
            {
                intenvory[itemCode]++;
            }

            Inventory.Refresh();
            Shop.Refresh();
        }


        public void RemoveInventoryItem(string itemCode)
        {
            if (intenvory.ContainsKey(itemCode))
            {
                intenvory[itemCode]--;

                if (intenvory[itemCode] == 0)
                {
                    intenvory.Remove(itemCode);
                }
            }

            Inventory.Refresh();
            Shop.Refresh();
        }


        public void UseInventoryItem(string itemCode)
        {
            Inventory.UseItem(itemCode);
        }
        #endregion


        #region Shop
        #endregion
    }
}