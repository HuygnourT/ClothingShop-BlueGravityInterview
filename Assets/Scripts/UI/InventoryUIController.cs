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
        public float stepSize = 1;

        [SerializeField] private InventoryUILayout _inventoryUILayout;

        int selectedItem;
        Vector2 firstItem;
        GameModel model; 

        void Start()
        {
            if (_inventoryUILayout != null)
            {
                _inventoryUILayout.gameObject.SetActive(false);
            }

            model = Schedule.GetModel<GameModel>();
            Refresh();
        }


        public void Refresh()
        {
            if (_inventoryUILayout == null)
            {
                return;
            }
   
            var displayCount = 0;
            foreach (var itemCode in model.InventoryItems)
            {
                var count = model.GetInventoryCount(itemCode);

                var item = model.GetItem(itemCode);

                _inventoryUILayout.SetupInventoryItem(displayCount, itemCode, item.SpriteItem, count);
                displayCount++;
            }
        }


        public void ShowOrHide()
        {
            _inventoryUILayout.Exit(selectedItem);
            selectedItem = -1;

            if (_inventoryUILayout != null)
            {
                bool isActive = !_inventoryUILayout.gameObject.activeSelf;

                if (isActive)
                {
                    Refresh();
                }
                else
                {
                    _inventoryUILayout.ClearItem();
                    _inventoryUILayout.Refresh();
                }

                _inventoryUILayout.gameObject.SetActive(isActive);
            }
        }


        public void FocusItem(int direction)
        {
            if (_inventoryUILayout == null)
            {
                return;
            }

            if (selectedItem < 0) selectedItem = 0;

            int maxIndex = _inventoryUILayout.GetEquipmentItemCount() + _inventoryUILayout.GetInventoryItemCount() - 1;

            if (selectedItem == maxIndex || (direction < 0 && selectedItem == 0))
            {
                return;
            }

            _inventoryUILayout.Exit(selectedItem);

            selectedItem += direction;
            selectedItem = Mathf.Clamp(selectedItem, 0, maxIndex);

            _inventoryUILayout.Enter(selectedItem);
        }


        public void UseItem()
        {
            if (_inventoryUILayout != null)
            {
                _inventoryUILayout.Click(selectedItem);
            }
        }


        public void UseItem(string itemCode)
        {
            var item = model.GetItem(itemCode);

            if (item != null && item.IsEquipment())
            {
                if (_inventoryUILayout != null)
                {
                    var equipmentItem = _inventoryUILayout.GetEquipmentItemUI((int)item.ItemType);

                    if (equipmentItem != null)
                    {
                        equipmentItem.Unequip();
                        equipmentItem.Setup(item.ItemCode, item.SpriteItem, 1);
                        model.Player.EquipItem(item.Skin, (int)item.ItemType);
                        ShowOrHide();
                        model.Input.ChangeState(InputController.State.CharacterControl);
                    }
                }
            }
        }


        public void RemoveUseItem(string itemCode)
        {

        }
    }
}

