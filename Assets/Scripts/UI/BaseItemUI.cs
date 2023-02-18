using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RPG.Utils;
using RPG.Gameplay;
using RPG.Core;

namespace RPG.UI
{
    public abstract class BaseItemUI : MonoBehaviour
    {
        [SerializeField] protected TextMeshPro _text;
        [SerializeField] protected SpriteRenderer _itemSpriteRender;

        protected string mItemCode = string.Empty;
        public string ItemCode { get { return mItemCode; } }
        Vector2 mDefaultSize = Vector2.one * 0.6f;

        protected GameModel mGameModel = Schedule.GetModel<GameModel>();

        public virtual void Setup(string itemCode, Sprite spriteItem, int amount)
        {
            mItemCode = itemCode;

            if (_itemSpriteRender != null)
            {
                _itemSpriteRender.sprite = spriteItem;
                _itemSpriteRender.size = mDefaultSize;
            }

            if (_text != null)
            {
                _text.text = amount.ToString();
            }
        }


        public virtual void Unequip()
        {

        }


        public virtual void Clear()
        {
            this.mItemCode = string.Empty;

            if (_itemSpriteRender != null)
            {
                _itemSpriteRender.sprite = null;
                _itemSpriteRender.size = mDefaultSize;
            }

            if (_text != null)
            {
                _text.text = "0";
            }
        }


        public virtual void Click()
        {

        }


        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }


        public virtual void Refresh()
        {

        }
    }
}
