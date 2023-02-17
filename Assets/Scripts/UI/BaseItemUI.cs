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
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private SpriteRenderer _itemSpriteRender;

        protected string mItemCode;
        Vector2 mDefaultSize = Vector2.one * 0.6f;

        protected GameModel mGameModel;

        //private 

        public virtual void Setup(string itemCode, Sprite spriteItem, int amount)
        {
            mItemCode = itemCode;
            mGameModel = Schedule.GetModel<GameModel>();

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
    }
}
