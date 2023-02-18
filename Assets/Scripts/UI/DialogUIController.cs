using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Gameplay;

namespace RPG.UI
{
    public class DialogUIController : MonoBehaviour
    {
        [SerializeField] private DialogUILayout _dialogUILayout;

        public System.Action<int> onButton;

        public int selectedButton = 0;
        public int buttonCount = 0;

        SpriteButton[] buttons;
        Camera mainCamera;
        GameModel model = Schedule.GetModel<GameModel>();
        SpriteUIElement spriteUIElement;
        public void FocusButton(int direction)
        {
            if (buttonCount > 0)
            {
                if (selectedButton < 0) selectedButton = 0;
                buttons[selectedButton].Exit();
                selectedButton += direction;
                selectedButton = Mathf.Clamp(selectedButton, 0, buttonCount - 1);
                buttons[selectedButton].Enter();
            }
        }

        public void SelectActiveButton()
        {
            if (buttonCount > 0)
            {
                if (selectedButton >= 0)
                {

                    model.Input.ChangeState(InputController.State.CharacterControl);
                    buttons[selectedButton].Click();
                    selectedButton = -1;
                }
            }
            else
            {
                //there are no buttons, just Hide when required.
                model.Input.ChangeState(InputController.State.CharacterControl);
                Hide();
            }
        }


        public void SetButton(int index, string text)
        {
            var d = _dialogUILayout;
            d.SetButtonText(index, text);
            buttonCount = Mathf.Max(buttonCount, index + 1);
        }


        public void Show(Vector3 position, string text)
        {
            var d = _dialogUILayout;
            d.gameObject.SetActive(true);
            d.SetText(text);
            SetPosition(position);
            model.Input.ChangeState(InputController.State.DialogControl);
            buttonCount = 0;
            selectedButton = -1;
        }


        public void Show(Vector3 position, string text, string buttonA)
        {
            var d = _dialogUILayout;
            d.gameObject.SetActive(true);
            d.SetText(text, buttonA);
            SetPosition(position);
            model.Input.ChangeState(InputController.State.DialogControl);
            buttonCount = 1;
            selectedButton = -1;
        }

        public void Show(Vector3 position, string text, string buttonA, string buttonB)
        {
            var d = _dialogUILayout;
            d.gameObject.SetActive(true);
            d.SetText(text, buttonA, buttonB);
            SetPosition(position);
            model.Input.ChangeState(InputController.State.DialogControl);
            buttonCount = 2;
            selectedButton = -1;
        }

        void SetPosition(Vector3 position)
        {
            var screenPoint = mainCamera.WorldToScreenPoint(position);
            position = spriteUIElement._camera.ScreenToViewportPoint(screenPoint);
            spriteUIElement._anchor = position;
        }

        public void Show(Vector3 position, string text, string buttonA, string buttonB, string buttonC)
        {
            var d = _dialogUILayout;
            d.gameObject.SetActive(true);
            d.SetText(text, buttonA, buttonB, buttonC);
            SetPosition(position);
            model.Input.ChangeState(InputController.State.DialogControl);
            buttonCount = 3;
            selectedButton = -1;
        }

        public void Hide()
        {
            _dialogUILayout.gameObject.SetActive(false);
        }

        public void SetIcon(Sprite icon) => _dialogUILayout.SetIcon(icon);

        void OnButton(int index)
        {
            if (onButton != null) onButton(index);
            onButton = null;
        }

        void Awake()
        {
            _dialogUILayout.gameObject.SetActive(false);
            buttons = _dialogUILayout.buttons;
            _dialogUILayout.buttonA.onClickEvent += () => OnButton(0);
            _dialogUILayout.buttonB.onClickEvent += () => OnButton(1);
            _dialogUILayout.buttonC.onClickEvent += () => OnButton(2);
            spriteUIElement = GetComponent<SpriteUIElement>();
            mainCamera = Camera.main;
        }
    }
}

