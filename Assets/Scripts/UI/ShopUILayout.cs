using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPG.UI
{
    public class ShopUILayout : MonoBehaviour
    {
        [SerializeField] private List<ShopItemUI> _shopItemUI;
        [SerializeField] private List<ShopItemUI> _inventoryItemUI;
        [SerializeField] private TextMeshPro _nameItem;
        [SerializeField] private TextMeshPro _descriptionItem;
        [SerializeField] private TextMeshPro _moneyText;
        [SerializeField] private TextMeshPro _priceText;

        public void Exit(int selectedItem)
        {
            if (selectedItem >= 0)
            {
                if (selectedItem < _shopItemUI.Count)
                {
                    _shopItemUI[selectedItem].Exit();
                }
                else
                {
                    _inventoryItemUI[selectedItem - _shopItemUI.Count].Exit();
                }
            }
        }


        public void Enter(int selectedItem)
        {
            if (selectedItem < _shopItemUI.Count)
            {
                _shopItemUI[selectedItem].Enter();   
            }
            else
            {
                _inventoryItemUI[selectedItem - _shopItemUI.Count].Enter();
            }
        }


        public void Click(int selectedItem)
        {
            if (selectedItem < _shopItemUI.Count)
            {
                // Unequip
                _shopItemUI[selectedItem].Click();
            }
            else
            {
                //Equip
                _inventoryItemUI[selectedItem - _shopItemUI.Count].Click();
            }
        }


        public void SetupInventoryItem(int displayCount, string itemCode, Sprite spriteItem, int amount)
        {
            _inventoryItemUI[displayCount].Setup(itemCode, spriteItem, amount);
        }


        public void SetupContentItem(string nameItem, string descriptionItem)
        {
            if (_nameItem != null)
            {
                _nameItem.text = nameItem;
            }

            if (_descriptionItem != null)
            {
                _descriptionItem.text = descriptionItem;
            }
        }


        public int GetShopItemCount()
        {
            if (_shopItemUI == null)
                return 0;

            return _shopItemUI.Count;
        }


        public int GetInventoryItemCount()
        {
            if (_inventoryItemUI == null)
                return 0;

            return _inventoryItemUI.Count;
        }    


        public void UpdateMoneyText(int remaining)
        {
            if (_moneyText != null)
            {
                _moneyText.text = remaining.ToString();
            }
        }


        public void UpdatePriceText(bool isBuy, int price)
        {
            if (_priceText != null)
            {
                if (isBuy)
                {
                    _priceText.text = "Buy : " + price.ToString();
                }
                else
                {
                    _priceText.text = "Sell : " + price.ToString();
                }
            }
        }


        public void UpdateItemForSell(int displayCount, string itemCode, Sprite spriteItem, int amount = 0)
        {
            _shopItemUI[displayCount].Setup(itemCode, spriteItem, amount);
        }


        public void ClearItemInShop()
        {
            foreach (var child in _shopItemUI)
            {
                child.Clear();
            }
        }    


        public void ClearItem()
        {
            foreach (var child in _inventoryItemUI)
            {
                child.Clear();
            }
        }
    }
}