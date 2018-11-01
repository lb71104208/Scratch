using UnityEngine;
using UI;
using Common;

namespace MainPlayer
{
    public class Player : Character.Character
    {

        private PlayerControl _playerControl;
        private PlayerProperty _playerProperty;
        private CharacterMotion _playerMotion;

        public int CurrentStamina
        {
            get { return _curStamina; }
            set
            {
                _curStamina = value;
                EventManager.Instance.SendNotification(NotificationType.PLAYER_STAMINA_CHANGE, _curStamina);
            }
        }
        private int _curStamina;
        private int _staminaCostPerUnit = 1;
        private float _distanceCounter;
        private const float STAMINA_CONSUME_UNIT = 1.0f;

        private void Awake()
        {
            _playerControl = GetComponent<PlayerControl>();
            _playerProperty = GetComponent<PlayerProperty>();
            _playerMotion = GetComponent<CharacterMotion>();
        }
        // Use this for initialization
        void Start()
        {
            CurrentStamina = _playerProperty.MaxStamina;
            _distanceCounter = 0;
        }

        public override void ConsumeStamina(float distance)
        {
            if(IsRunOutOfStamina())
            {
                return;
            }
            _distanceCounter += distance;
            if(_distanceCounter > STAMINA_CONSUME_UNIT)
            {
                int consume = (int)STAMINA_CONSUME_UNIT * _staminaCostPerUnit;
                CurrentStamina = _curStamina - consume;

                if(_curStamina <= 0)
                {
                    OnRunOutOfStamina();
                }
                _distanceCounter = 0;
            }
        }

        private void OnRunOutOfStamina()
        {
            _playerMotion.Stop();
        }

        public bool IsRunOutOfStamina()
        {
            return _curStamina <= 0;
        }

        public void RestoreState()
        {
            CurrentStamina = _playerProperty.MaxStamina;
        }

        public void OnEnterScene(int sceneIndex)
        {
            _playerControl.OnEnterScene(sceneIndex);
        }

    }
}


