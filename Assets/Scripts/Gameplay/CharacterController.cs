using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using RPG.Utils;

namespace RPG.Gameplay
{
    public class CharacterController : MonoBehaviour
    {
        /// <summary>
        /// A simple controller for animating a 4 directional sprite using Physics.
        /// </summary>
        [SerializeField] private float speed = 1;
        [SerializeField] private float acceleration = 2;

        private Animator mAnimator;
        private Rigidbody2D mRigidbody2D;
        private PixelPerfectCamera mPixelPerfectCamera;
        private bool mIsFlipX = false;
        private Vector3 mNextMoveCommand;

        private enum State
        {
            Idle, 
            Walk,
            Run 
        }

        private State mCurrentState = State.Idle;
        private Vector3 mStartMove, mEndMove;
        private Vector2 mCurrentVelocity;
        private float mVelocity;
        private float distance;


        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mAnimator = GetComponent<Animator>();
            mPixelPerfectCamera = FindObjectOfType<PixelPerfectCamera>();
        }


        private void Update()
        {
            UpdateStateAnimator();
        }


        private void LateUpdate()
        {
            if (mPixelPerfectCamera != null)
            {
                transform.position = mPixelPerfectCamera.RoundToPixel(transform.position);
            }
        }


        private void UpdateStateAnimator()
        {
            switch (mCurrentState)
            {
                case State.Idle:
                    IdleState();
                    break;

                case State.Walk:
                    MoveState();
                    break;

                case State.Run:
                    MoveState();
                    break;
            }
        }


        private void IdleState()
        {
            mStartMove = transform.position;
            mEndMove = mStartMove + mNextMoveCommand;
            distance = (mEndMove - mStartMove).magnitude;
            mVelocity = 0;
            UpdateAnimator(mNextMoveCommand);
            mNextMoveCommand = Vector3.zero;

            mAnimator.SetBool(GameConst.ANIMATION_PARAM_RUNNING, false);
        }


        private void MoveState()
        {
            mVelocity = Mathf.Clamp01(mVelocity + Time.deltaTime * acceleration);
            UpdateAnimator(mNextMoveCommand);
            mRigidbody2D.velocity = Vector2.SmoothDamp(mRigidbody2D.velocity, mNextMoveCommand * speed, ref mCurrentVelocity, acceleration, speed);
            mIsFlipX = mRigidbody2D.velocity.x >= 0 ? true : false;

            if (mIsFlipX)
            {
                transform.localScale = Vector3.one;
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            mAnimator.SetBool(GameConst.ANIMATION_PARAM_RUNNING, true);
        }


        private void UpdateAnimator(Vector3 direction)
        {

            if (direction != Vector3.zero)
            {
                mCurrentState = State.Run;
            }
            else
            {
                mCurrentState = State.Idle;
            }
        }


        public void UpdateNextMoveCommand(Vector3 newNextMoveCommand)
        {
            this.mNextMoveCommand = newNextMoveCommand;
        }
    }
}
