using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Gameplay
{
    public class InputController : MonoBehaviour
    {
        public float stepSize = 0.1f;
        private GameModel mModel;
        private State mState;

        public enum State
        {
            CharacterControl,
            DialogControl,
            InventoryControl,
            Pause
        }


        private void Start()
        {
            mModel = Schedule.GetModel<GameModel>();
        }


        private void Update()
        {
            UpdateState();
        }


        private void UpdateState()
        {
            switch (mState)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                case State.DialogControl:
                    DialogControl();
                    break;
            }
        }


        private void DialogControl()
        {
            if (mModel == null)
            {
                return;
            }

            if (mModel.Player != null)
            {
                mModel.Player.UpdateNextMoveCommand(Vector3.zero);
            }

            if (mModel.Dialog != null)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    mModel.Dialog.FocusButton(-1);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    mModel.Dialog.FocusButton(+1);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    mModel.Dialog.SelectActiveButton();
                }
            }

        }


        private void CharacterControl()
        {
            if (mModel == null)
            {
                return;
            }

            if (mModel.Player != null)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                    mModel.Player.UpdateNextMoveCommand(Vector3.up * stepSize);
                else if (Input.GetKey(KeyCode.DownArrow))
                    mModel.Player.UpdateNextMoveCommand(Vector3.down * stepSize);
                else if (Input.GetKey(KeyCode.LeftArrow))
                    mModel.Player.UpdateNextMoveCommand(Vector3.left * stepSize);
                else if (Input.GetKey(KeyCode.RightArrow))
                    mModel.Player.UpdateNextMoveCommand(Vector3.right * stepSize);
                else
                    mModel.Player.UpdateNextMoveCommand(Vector3.zero);
            }
        }


        public void ChangeState(State state) => this.mState = state;
    }
}