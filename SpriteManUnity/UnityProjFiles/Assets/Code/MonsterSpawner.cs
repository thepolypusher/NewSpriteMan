﻿using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class MonsterSpawner : MonoBehaviour
    {
        public ArrayList flags;
        private bool _isActive = true;
        private bool _hasMonster = false;

        public void Awake()
        {
            //find the scene manager
            //find the active scene
            //add self to monster list in scene
        }

        public void SpawnMonster(Monster newmonster)
        {
            if (_isActive)
            {
                newmonster = Instantiate(newmonster, transform.position, transform.rotation) as Monster;
                Debug.Log("spawning a monster!");
                _hasMonster = true;
            }
        }
    }
}
