using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Gameplay;
using RPG.Core;
using TMPro;

namespace RPG.UI
{
    public class InventoryUIController : MonoBehaviour
    {
        //public Transform elementPrototype;
        public float stepSize = 1;

        [SerializeField] private List<EquipmentItemUI> _equipmentItemUI;
        [SerializeField] private List<InventoryItemUI> _inventoryItemUI;

        int selectedItem;
        Vector2 firstItem;
        GameModel model; 
        SpriteUIElement sizer;

        void Start()
        {
            gameObject.SetActive(false);
            model = Schedule.GetModel<GameModel>();
            sizer = GetComponent<SpriteUIElement>();
            Refresh();
        }

        public void Refresh()
        {
            var cursor = firstItem;
            for (var i = 1; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
            var displayCount = 0;
            foreach (var itemCode in model.InventoryItems)
            {
                var count = model.GetInventoryCount(itemCode);
                if (count <= 0) continue;

                var item = model.GetItem(itemCode);

                _inventoryItemUI[displayCount].Setup(itemCode, item.SpriteItem, count);
                displayCount++;
            }
        }


        public void ShowOrHide()
        {
            selectedItem = -1;
            gameObject.SetActive(!gameObject.activeSelf);
        }


        public void FocusItem(int direction)
        {
            if (selectedItem < 0) selectedItem = 0;

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
            

            selectedItem += direction;
            selectedItem = Mathf.Clamp(selectedItem, 0, _equipmentItemUI.Count + _inventoryItemUI.Count - 1);

            if (selectedItem < _equipmentItemUI.Count)
            {
                _equipmentItemUI[selectedItem].Enter();
            }
            else
            {
                _inventoryItemUI[selectedItem - _equipmentItemUI.Count].Enter();
            }
        }


        public void UseItem()
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


        public void UseItem(string itemCode)
        {
            var item = model.GetItem(itemCode);

            if (item.IsEquipment())
            {
                _equipmentItemUI[(int)item.ItemType].Setup(item.ItemCode, item.SpriteItem, 1);

                model.Player.EquipItem(item.Skin, (int)item.ItemType);
            }
        }
    }
}

