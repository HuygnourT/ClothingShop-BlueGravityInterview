using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Gameplay
{
    /// <summary>
    /// A simple camera follower class. It saves the offset from the
    ///  focus position when started, and preserves that offset when following the focus.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _focusTarget;
        [SerializeField] private float smoothTime = 2;

        Vector3 mOffset;

        void Awake()
        {
            if (_focusTarget != null)
            {
                mOffset = _focusTarget.position - transform.position;
            }
        }

        void Update()
        {
            if (_focusTarget != null)
                transform.position = Vector3.Lerp(transform.position, _focusTarget.position - mOffset, Time.deltaTime * smoothTime);
        }
    }
}