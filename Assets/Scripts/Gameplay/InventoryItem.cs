using RPG.Core;
using UnityEngine;
using RPG.ScriptableObjects;
using TMPro;

namespace RPG.Gameplay
{
    /// <summary>
    /// Marks a gameObject as a collectable item.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(CircleCollider2D))]
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private InventoryItemConfiguration _inventoryItemConfiguration;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TextMeshPro _textMeshPro;

        private string mNameItem;
        private int mCount = 1;
        private Sprite mSprite;
        private GameModel mModel;

        private void Start()
        {
            mModel = Schedule.GetModel<GameModel>();
            Setup(_inventoryItemConfiguration);
        }


        void Reset()
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }


        public void OnTriggerEnter2D(Collider2D collider)
        {
            mModel.AddInventoryItem(_inventoryItemConfiguration.ItemCode);
            gameObject.SetActive(false);
        }


        public void Setup(InventoryItemConfiguration inventoryItemConfiguration)
        {
            this._inventoryItemConfiguration = inventoryItemConfiguration;

            if (_inventoryItemConfiguration != null)
            {
                mSprite = inventoryItemConfiguration.SpriteItem;
                mNameItem = inventoryItemConfiguration.NameItem;
            }

            if (_spriteRenderer != null)
            {
                _spriteRenderer.sprite = mSprite;
            }

            if (_textMeshPro != null)
            {
                _textMeshPro.text = mNameItem;
            }
        }


        public Sprite GetSpriteItem()
        {
            return mSprite;
        }


        public int GetCountItem()
        {
            return mCount;
        }
    }
}