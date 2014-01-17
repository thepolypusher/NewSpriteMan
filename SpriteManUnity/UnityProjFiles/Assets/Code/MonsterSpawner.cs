using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Code
{
    public class MonsterSpawner : MonoBehaviour
    {
        private bool _isActive = true;
        private bool _hasMonster = false;

        public void Awake()
        {
        }

        public void SpawnMonster(Monster newmonster)
        {
            if (_isActive)
            {
                //debug monster spawning until Director is hooked up. Spawns the scene's default monster
                //add 'level' to the function arguments to pass that on to Init
                newmonster = Instantiate(newmonster, transform.position, transform.rotation) as Monster;
                newmonster.Init(1);
                _hasMonster = true;
            }
        }
    }
}
