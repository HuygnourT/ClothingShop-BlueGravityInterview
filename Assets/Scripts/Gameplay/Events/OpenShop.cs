using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Gameplay;

namespace RPG.Events
{
    public class OpenShop : Event<OpenShop>
    {
        public override void Execute()
        {
            model.Shop.ShowOrHide();
        }
    }
}