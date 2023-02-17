using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace RPG.Gameplay
{
    public class CharacterSkin : MonoBehaviour
    {
        [SerializeField] private SpriteLibrary _skinSprite;
        [SerializeField] private SpriteLibrary _hairSprite;
        [SerializeField] private SpriteLibrary _shirtSprite;
        [SerializeField] private SpriteLibrary _pantSprite;


        public void EquipItem(SpriteLibraryAsset skin, int index)
        {
            Debug.Log($"EquipItem {index}");
            switch (index)
            {
                case 0:
                    ChangeHair(skin);
                    break;

                case 1:
                    ChangeSkin(skin);
                    break;

                case 2:
                    ChangeShirt(skin);
                    break;

                case 3:
                    ChangePant(skin);
                    break;
            }
        }



        public void ChangeSkin(SpriteLibraryAsset newSkin)
        {
            if (_skinSprite != null)
            {
                _skinSprite.spriteLibraryAsset = newSkin;
            }
        }


        public void ChangeHair(SpriteLibraryAsset newHair)
        {
            if (_hairSprite != null)
            {
                _hairSprite.spriteLibraryAsset = newHair;
            }
        }


        public void ChangeShirt(SpriteLibraryAsset newShirt)
        {
            if (_shirtSprite != null)
            {
                _shirtSprite.spriteLibraryAsset = newShirt;
            }
        }

        public void ChangePant(SpriteLibraryAsset newPant)
        {
            if (_pantSprite != null)
            {
                _pantSprite.spriteLibraryAsset = newPant;
            }
        }
    }
}

