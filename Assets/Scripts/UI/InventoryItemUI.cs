using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RPG.Utils;

namespace RPG.UI
{
    public class InventoryItemUI : BaseItemUI
    {
        [SerializeField] private Animator _itemSelectAnimator;
        [SerializeField] private Transform _amountItemTransform;

        public override void Setup(string itemCode, Sprite spriteItem, int amount)
        {
            base.Setup(itemCode, spriteItem, amount);

            if (_amountItemTransform != null)
            {
                _amountItemTransform.gameObject.SetActive(amount != 0);
            }
        }


        public override void Clear()
        {
            base.Clear();

            if (_amountItemTransform != null)
            {
                _amountItemTransform.gameObject.SetActive(false);
            }
        }


        public override void Click()
        {
            base.Click();

            if (mGameModel != null)
            {
                mGameModel.UseInventoryItem(mItemCode);
                mGameModel.RemoveInventoryItem(mItemCode);
            }

            Clear();
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
    }
}

