using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace RPG.UI
{
    public class SpriteUIElement : MonoBehaviour
    {
        public Camera _camera;

        public int _pixelsPerUnit = 64;
        public Vector2 _anchor;
        public Vector2 _offset;
        public Vector2 _hideOffset;


        [SerializeField] private AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private float animationDuration = 0.5f;

        private SpriteRenderer mSpriteRenderer;
        private PixelPerfectCamera mPixelPerfectCamera;
        private Vector2 mAnimationOffset;

        private float t = 0;
        private float mDirection = 0;

        [ContextMenu("Show")]
        public void Show()
        {
            mDirection = 1;
        }

        [ContextMenu("Hide")]
        public void Hide()
        {
            mDirection = -1;
        }

        public void Toggle()
        {
            mDirection *= -1;
        }

        void OnEnable()
        {
            mSpriteRenderer = GetComponent<SpriteRenderer>();

            if (Application.isPlaying)
                mPixelPerfectCamera = _camera.GetComponent<PixelPerfectCamera>();
            _anchor.x = Mathf.Round(_anchor.x * _pixelsPerUnit) / _pixelsPerUnit;
            _anchor.y = Mathf.Round(_anchor.y * _pixelsPerUnit) / _pixelsPerUnit;
        }

        void Update()
        {
            if (_camera != null)
            {
                t = Mathf.Clamp01(t + (mDirection * Time.deltaTime / animationDuration));

                mAnimationOffset = Vector2.LerpUnclamped(_hideOffset, Vector3.zero, curve.Evaluate(t));
                var p = (Vector2)_camera.ViewportToWorldPoint(_anchor + _offset + mAnimationOffset);
                transform.position = p;
                if (mPixelPerfectCamera != null && Application.isPlaying)
                {
                    transform.position = mPixelPerfectCamera.RoundToPixel(transform.position);
                }
            }
        }
    }
}

