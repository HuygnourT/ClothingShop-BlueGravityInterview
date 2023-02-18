using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{
    public class InventoryUILayout : MonoBehaviour
    {
        [SerializeField] private List<EquipmentItemUI> _equipmentItemUI;
        [SerializeField] private List<InventoryItemUI> _inventoryItemUI;

        public void Exit(int selectedItem)
        {
            if (selectedItem >= 0)
            {
                if (selectedItem < _equipmentItemUI.Count)
                {
                    _equipmentItemUI[selectedItem].Exit();
                }
                else
                {
                    _inventoryItemUI[selectedItem - _equipmentItemUI.Count].Exit();
                }
            }
        }


        public void Enter(int selectedItem)
        {
            if (selectedItem < _equipmentItemUI.Count)
            {
                _equipmentItemUI[selectedItem].Enter();
            }
            else
            {
                _inventoryItemUI[selectedItem - _equipmentItemUI.Count].Enter();
            }
        }


        public void Click(int selectedItem)
        {
            if (selectedItem < _equipmentItemUI.Count)
            {
                // Unequip
                _equipmentItemUI[selectedItem].Click();
            }
            else
            {
                //Equip
                _inventoryItemUI[selectedItem - _equipmentItemUI.Count].Click();
            }
        }


        public void SetupInventoryItem(int displayCount, string itemCode, Sprite spriteItem, int amount)
        {
            _inventoryItemUI[displayCount].Setup(itemCode, spriteItem, amount);
        }


        public EquipmentItemUI GetEquipmentItemUI(int indexEquipmentItemUI)
        {
            if (_equipmentItemUI == null || indexEquipmentItemUI < 0 || indexEquipmentItemUI >= _equipmentItemUI.Count)
                return null;

            return _equipmentItemUI[indexEquipmentItemUI];
        }


        public int GetEquipmentItemCount()
        {
            if (_equipmentItemUI == null)
                return 0;

            return _equipmentItemUI.Count;
        }


        public int GetInventoryItemCount()
        {
            if (_inventoryItemUI == null)
                return 0;

            return _inventoryItemUI.Count;
        }


        public void Refresh()
        {
            //_equipmentItemUI
            foreach (var child in _inventoryItemUI)
            {
                child.Refresh();
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