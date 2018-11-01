using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace MainPlayer
{
    public class PlayerControl : MonoBehaviour
    {
        private EPlayerControlMode _controlMode = EPlayerControlMode.KEYBOARD;
        private CharacterMotion _playerMotion;
        private PlayerAction _playerAction;
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _playerMotion = GetComponent<CharacterMotion>();
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

            _playerMotion.MoveDirection(h, v);

            _playerAction.Move(h, v);
        }

        

        public void OnEnterScene(int sceneIndex)
        {

        }

    }
}
