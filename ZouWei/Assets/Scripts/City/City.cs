using UnityEngine;
using Common;

namespace Game
{
    public class City : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("Enters city!");
                LevelManager.Instance.EnterLevel(ELevel.Battle);
            }
        }
    }
}

