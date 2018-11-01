using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Character
{
    public class CharacterAction : MonoBehaviour
    {
        private Character _character;

        public void Move(float h, float v)
        {
            Vector3 offset = new Vector2(h, v) * Time.deltaTime * 2;
            transform.position += offset;
            _character.ConsumeStamina(offset.magnitude);
        }
    }
}
