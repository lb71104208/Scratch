using UnityEngine;
using UI;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public UIPlayerStatus playerStatusHud;

        private PlayerControl _playerControl;
        private PlayerProperty _playerProperty;

        public int CurrentStamina
        {
            get { return _curStamina; }
            set
            {
                _curStamina = value;
                playerStatusHud.UpdateStamina(_curStamina);
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
        }
        // Use this for initialization
        void Start()
        {
            CurrentStamina = _playerProperty.MaxStamina;
            _distanceCounter = 0;
        }

        public void ConsumeStamina(float distance)
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
            _playerControl.Stop();
        }

        public bool IsRunOutOfStamina()
        {
            return _curStamina <= 0;
        }

    }
}


