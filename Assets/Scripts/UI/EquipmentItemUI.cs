using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RPG.Utils;

namespace RPG.UI
{
    public class EquipmentItemUI : BaseItemUI
    {
        [SerializeField] private Animator _itemSelectAnimator;
        [SerializeField] private string _nameEquipmentItem;

        public override void Setup(string itemCode, Sprite spriteItem, int amount)
        {
            base.Setup(itemCode, spriteItem, amount);
            if (_text != null)
            {
                _text.text = _nameEquipmentItem;
                _text.gameObject.SetActive(spriteItem == null);
            }
        }


        public override void Unequip()
        {
            if (mItemCode.Equals(string.Empty))
            {
                return;
            }

            base.Unequip();

            if (mGameModel != null)
            {
                mGameModel.AddInventoryItem(mItemCode);
            }
        }


        public override void Click()
        {
            base.Click();

            Debug.Log($"EquipmentItemUI click {mItemCode} {mGameModel != null}");

            if (mGameModel != null)
            {   
                mGameModel.AddInventoryItem(mItemCode);
            }
            
            Clear();
        }


        public override void Clear()
        {
            base.Clear();

            if (_text != null)
            {
                _text.text = _nameEquipmentItem;
            }
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

