using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotion : MonoBehaviour {

    public Animator animator;
    public Sprite idleSideSprite;
    public Sprite idleUpSprite;
    public Sprite idleDownSprite;

    private EPlayerMoveDirection _moveDirection = EPlayerMoveDirection.NONE;
    private Dictionary<EPlayerMoveDirection, Sprite> _idleSpriteDic;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        SetupIdleSpriteDictionary();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void SetupIdleSpriteDictionary()
    {
        _idleSpriteDic = new Dictionary<EPlayerMoveDirection, Sprite>();
        _idleSpriteDic.Add(EPlayerMoveDirection.LEFT, idleSideSprite);
        _idleSpriteDic.Add(EPlayerMoveDirection.RIGHT, idleSideSprite);
        _idleSpriteDic.Add(EPlayerMoveDirection.UP, idleUpSprite);
        _idleSpriteDic.Add(EPlayerMoveDirection.DOWN, idleDownSprite);
    }

    public void MoveDirection(float h, float v)
    {
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
    }

    private EPlayerMoveDirection DetermineDirection(float h, float v)
    {
        if (h != 0)
        {
            return h > 0 ? EPlayerMoveDirection.RIGHT : EPlayerMoveDirection.LEFT;
        }
        else if (v != 0)
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

        if (_moveDirection == EPlayerMoveDirection.LEFT)
        {
            animator.SetInteger("MoveDirection", (int)EPlayerMoveDirection.RIGHT);
        }
        else
        {
            animator.SetInteger("MoveDirection", (int)_moveDirection);
        }

        if (_moveDirection == EPlayerMoveDirection.LEFT)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
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
}
