using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class MonsterSpawner : MonoBehaviour
    {
        public ArrayList flags;
        private bool _isActive = false;
        private bool _hasMonster = false;

        public void Awake()
        {
            //find the scene manager
            //find the active scene
            //add self to chest list in scene
        }

        public void SpawnMonster(Monster newmonster)
        {
            if (_isActive)
            {
                newmonster = Instantiate(newmonster, transform.position, transform.rotation) as Monster;
                _hasMonster = true;
            }
        }
    }
}
