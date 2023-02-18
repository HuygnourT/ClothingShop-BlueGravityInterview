using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Gameplay;
using UnityEngine.EventSystems;
using System;

namespace RPG.UI
{
    public class ShopUIController : MonoBehaviour
    {
        public float stepSize = 1;

        [SerializeField] private ShopUILayout _shopUILayout;

        int selectedItem;
        Vector2 firstItem;
        GameModel model;
        int mMoneyRemaining = 0;
        ItemInShop mItemShop;

        const int MONEY_DEFAULT = 1000;

        void Start()
        {
            if (_shopUILayout != null)
            {
                _shopUILayout.gameObject.SetActive(false);
            }

            model = Schedule.GetModel<GameModel>();
            UpdateMoney(MONEY_DEFAULT, true);
            Refresh();
        }


        public void Refresh()
        {
            if (_shopUILayout == null)
            {
                return;
            }

            _shopUILayout.ClearItem();
            SetupContentItem(string.Empty, string.Empty);

            var displayCount = 0;
            foreach (var itemCode in model.InventoryItems)
            {   
                var count = model.GetInventoryCount(itemCode);
                //if (count <= 0) continue;

                var item = model.GetItem(itemCode);

                _shopUILayout.SetupInventoryItem(displayCount, itemCode, item.SpriteItem, count);
                displayCount++;
            }
        }


        public void ShowOrHide()
        {
            _shopUILayout.Exit(selectedItem);
            selectedItem = -1;

            if (_shopUILayout != null)
            {
                bool isActive = !_shopUILayout.gameObject.activeSelf;
                _shopUILayout.gameObject.SetActive(isActive);
            }
        }


        public void UpdateItemForSell(ItemInShop itemInShop)
        {
            if (_shopUILayout == null || model == null)
            {
                return;
            }

            _shopUILayout.ClearItemInShop();

            mItemShop = itemInShop;
            int displayCount = 0;
            foreach (var child in mItemShop._itemShops)
            {
                var item = model.GetItem(child._itemCode);

                if (item == null)
                    continue;

                _shopUILayout.UpdateItemForSell(displayCount, child._itemCode, item.SpriteItem);
                displayCount++;
            }
        }



        public void FocusItem(int direction)
        {
            if (_shopUILayout == null)
            {
                return;
            }

            if (selectedItem < 0) selectedItem = 0;

            int maxIndex = _shopUILayout.GetShopItemCount() + _shopUILayout.GetInventoryItemCount() - 1;

            if (selectedItem == maxIndex || (direction < 0 && selectedItem == 0) )
            {
                return;
            }

            _shopUILayout.Exit(selectedItem);

            selectedItem += direction;
            selectedItem = Mathf.Clamp(selectedItem, 0, maxIndex);

            _shopUILayout.Enter(selectedItem);
        }


        public void UseItem()
        {
            if (_shopUILayout != null)
            {
                _shopUILayout.Click(selectedItem);
            }
        }


        public void SetupContentItem(string nameItem, string descriptionItem)
        {
            if (_shopUILayout != null)
            {
                _shopUILayout.SetupContentItem(nameItem, descriptionItem);
            }
        }


        public void SetupPriceTag(bool isForBuy, string itemCode)
        {
            int price = 0;
            if (isForBuy)
            {
                price = GetPriceForBuy(itemCode);
            }
            else
            {
                price = GetPriceForSell(itemCode);
            }

            _shopUILayout.UpdatePriceText(isForBuy, price);
        }


        public void UpdateMoney(int moneyChanged , bool isIncrease)
        {
            if (isIncrease)
            {
                mMoneyRemaining += moneyChanged;
            }
            else
            {
                mMoneyRemaining -= moneyChanged;
            }

            if (_shopUILayout != null)
            {
                _shopUILayout.UpdateMoneyText(mMoneyRemaining);
            }
        }


        public int GetPriceForBuy(string itemCode)
        {
            if (mItemShop._itemShops != null)
            {
                foreach (var child in mItemShop._itemShops)
                {
                    if (child._itemCode == itemCode)
                    {
                        return child._priceForBuy;
                    }
                }
            }

            return 0;
        }


        public int GetPriceForSell(string itemCode)
        {
            if (mItemShop._itemShops != null)
            {
                foreach (var child in mItemShop._itemShops)
                {
                    if (child._itemCode == itemCode)
                    {
                        return child._priceForSell;
                    }
                }

                return mItemShop._priceDefaultForSell;
            }

            return 0;
        }


        public void BuyItem(string itemCode)
        {
            if (mItemShop._itemShops != null)
            {
                foreach (var child in mItemShop._itemShops)
                {
                    if (child._itemCode == itemCode && child._priceForBuy <= mMoneyRemaining)
                    {
                        // Purchase Item
                        model.AddInventoryItem(itemCode);
                        UpdateMoney(child._priceForBuy, false);
                        return;
                    }
                }
            }
        }


        public void SellItem(string itemCode)
        {
            if (mItemShop._itemShops != null)
            {
                Debug.Log("SellItem " + itemCode);

                foreach (var child in mItemShop._itemShops)
                {
                    if (child._itemCode == itemCode)
                    {
                        // Purchase Item
                        model.RemoveInventoryItem(itemCode);
                        UpdateMoney(child._priceForSell, true);
                        return;
                    }
                }

                model.RemoveInventoryItem(itemCode);
                UpdateMoney(mItemShop._priceDefaultForSell, true);
            }
        }
    }
}