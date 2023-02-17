using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RPG.Utils;

namespace RPG.UI
{
    public class EquipmentItemUI : BaseItemUI
    {
        public override void Click()
        {
            base.Click();

            if (mGameModel != null)
            {
                mGameModel.AddInventoryItem(mItemCode);
            }
            
            Clear();
        }


        public override void Enter()
        {
        }


        public override void Exit()
        {
        }
    }
}

