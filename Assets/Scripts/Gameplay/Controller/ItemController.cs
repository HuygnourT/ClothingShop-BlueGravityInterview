using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.ScriptableObjects;


namespace RPG.Gameplay
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] private List<InventoryItemConfiguration> _inventoryItemConfigurations;

        public InventoryItemConfiguration GetInventoryItemConfiguration(string itemCode)
        {
            if (_inventoryItemConfigurations == null)
                return null;

            foreach (var child in _inventoryItemConfigurations)
            {
                if (child.ItemCode == itemCode)
                {
                    return child;
                }
            }

            return null;
        }
    }
}