using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum PlayerMoveDirection
    {
        LEFT = 0,
        RIGHT,
        UP,
        DOWN,
        NONE = -1
    }

    public class PlayerControl : MonoBehaviour
    {

        private PlayerMoveDirection _moveDirection = PlayerMoveDirection.NONE;
        public Animator animator;

        private void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h != 0)
            {
                PlayerMoveDirection direction = h > 0 ? PlayerMoveDirection.RIGHT : PlayerMoveDirection.LEFT;
                if (direction != _moveDirection)
                {
                    _moveDirection = direction;
                    animator.SetInteger("MoveDirection", (int)direction);
                }
            }
            else
            {
                animator.SetInteger("MoveDirection", (int)PlayerMoveDirection.NONE);
                _moveDirection = PlayerMoveDirection.NONE;
            }

            Vector3 offset = new Vector2(h, v) * Time.deltaTime * 2;
            transform.position += offset;
        }
    }
}
