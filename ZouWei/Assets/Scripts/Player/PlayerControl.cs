using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Player
{
    public enum EPlayerMoveDirection
    {
        NONE = 0,
        LEFT ,
        RIGHT,
        UP,
        DOWN
    }

    enum EPlayerControlMode
    {
        KEYBOARD,
        MOUSE
    }

    public class PlayerControl : MonoBehaviour
    {
        public Animator animator;
        public Sprite idleSideSprite;
        public Sprite idleUpSprite;
        public Sprite idleDownSprite;

        private EPlayerMoveDirection _moveDirection = EPlayerMoveDirection.NONE;
        private Dictionary<EPlayerMoveDirection, Sprite> _idleSpriteDic;
        private SpriteRenderer _sprite;
        private Player _player;
        private EPlayerControlMode _controlMode = EPlayerControlMode.KEYBOARD;

        private void Awake()
        {
            SetupIdleSpriteDictionary();
            _sprite = GetComponent<SpriteRenderer>();
            _player = GetComponent<Player>();
        }

        private void SetupIdleSpriteDictionary()
        {
            _idleSpriteDic = new Dictionary<EPlayerMoveDirection, Sprite>();
            _idleSpriteDic.Add(EPlayerMoveDirection.LEFT, idleSideSprite);
            _idleSpriteDic.Add(EPlayerMoveDirection.RIGHT, idleSideSprite);
            _idleSpriteDic.Add(EPlayerMoveDirection.UP, idleUpSprite);
            _idleSpriteDic.Add(EPlayerMoveDirection.DOWN, idleDownSprite);
        }
        
        private void Update()
        {
            if(_controlMode == EPlayerControlMode.KEYBOARD)
            {
                OnKeyboardInput();
            }
        }

        private void OnKeyboardInput()
        {
            if (_player.IsRunOutOfStamina())
            {
                return;
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            EPlayerMoveDirection direction = DetermineDirection(h, v);
            if (direction != _moveDirection)
            {
                if (direction == EPlayerMoveDirection.NONE)
                {
                    Stop();
                }
                else
                {
                    _moveDirection = direction;
                    PlayMoveAnimation();
                }

            }

            Move(h, v);
        }

        private EPlayerMoveDirection DetermineDirection(float h, float v)
        {
            if(h != 0)
            {
                return h > 0 ? EPlayerMoveDirection.RIGHT : EPlayerMoveDirection.LEFT;
            }
            else if( v != 0)
            {
                return v > 0 ? EPlayerMoveDirection.UP : EPlayerMoveDirection.DOWN;
            }
            else
            {
                return EPlayerMoveDirection.NONE;
            }
        }

        private void PlayMoveAnimation()
        {
            //leave face state
            animator.SetInteger("FaceDirection", 0);

            if(_moveDirection == EPlayerMoveDirection.LEFT)
            {
                animator.SetInteger("MoveDirection", (int)EPlayerMoveDirection.RIGHT);
            }
            else
            {
                animator.SetInteger("MoveDirection", (int)_moveDirection);
            }
            
            if(_moveDirection == EPlayerMoveDirection.LEFT)
            {
                _sprite.flipX = true;
            }
            else
            {
                _sprite.flipX = false;
            }
        }

        private void Move(float h, float v)
        {
            Vector3 offset = new Vector2(h, v) * Time.deltaTime * 2;
            transform.position += offset;
            _player.ConsumeStamina(offset.magnitude);
        }

        public void Stop()
        {
            OnEnterIdleState(_moveDirection);
            _moveDirection = EPlayerMoveDirection.NONE;
        }

        private void OnEnterIdleState(EPlayerMoveDirection faceDir)
        {
            if (faceDir == EPlayerMoveDirection.LEFT)
            {
                faceDir = EPlayerMoveDirection.RIGHT;
                _sprite.flipX = true;
            }
            else
            {
                _sprite.flipX = false;
            }

            //leave move state
            animator.SetInteger("MoveDirection", 0);

            animator.SetInteger("FaceDirection", (int)faceDir);
        }

        public void OnEnterScene(int sceneIndex)
        {
            ELevel level = (ELevel)sceneIndex;
            SwitchControlMode(level);
        }

        private void SwitchControlMode(ELevel level)
        {
            switch(level)
            {
                case ELevel.World:
                    _controlMode = EPlayerControlMode.KEYBOARD;
                    break;

                default:
                    _controlMode = EPlayerControlMode.MOUSE;
                    break;

            }
        }

        private void OnMouseUp()
        {
           if(_controlMode == EPlayerControlMode.MOUSE)
            {

            }
        }
    }
}
