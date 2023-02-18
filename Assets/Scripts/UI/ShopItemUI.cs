using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RPG.Utils;

namespace RPG.UI
{
    public class ShopItemUI : BaseItemUI
    {
        [SerializeField] private bool _isShopItem;
        [SerializeField] private Animator _itemSelectAnimator;
        public override void Setup(string itemCode, Sprite spriteItem, int amount)
        {
            base.Setup(itemCode, spriteItem, amount);
        }


        public override void Click()
        {
            base.Click();
            if (mGameModel != null)
            {
                if (_isShopItem)
                {
                    mGameModel.Shop.BuyItem(mItemCode);
                }
                else
                {
                    mGameModel.Shop.SellItem(mItemCode);
                }
            }    
        }


        public override void Clear()
        {
            base.Clear();
        }


        public override void Enter()
        {
            if (_itemSelectAnimator != null)
            {
                if (_itemSelectAnimator.enabled == false)
                {
                    _itemSelectAnimator.enabled = true;
                }

                _itemSelectAnimator.Play(GameConst.ANIMATION_ITEM_SELECT);

                mGameModel.Shop.SetupPriceTag(_isShopItem, mItemCode);
            }

            if (mGameModel != null)
            {
                string nameItem = mGameModel.GetNameItem(mItemCode);
                string descriptionItem = mGameModel.GetDescriptionItem(mItemCode);

                mGameModel.Shop.SetupContentItem(nameItem, descriptionItem);
            }
        }


        public override void Exit()
        {
            if (_itemSelectAnimator != null)
            {
                if (_itemSelectAnimator.enabled == false)
                {
                    _itemSelectAnimator.enabled = true;
                }

                _itemSelectAnimator.Play(GameConst.ANIMATION_ITEM_UNSELECT);
            }
        }


        public override void Refresh()
        {
            if (_itemSelectAnimator != null)
            {
                _itemSelectAnimator.enabled = false;
            }
        }
    }
}

