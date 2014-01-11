using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code
{
    public class Monster : MonoBehaviour
    {
        private string 
            _name,
            _type;
        private int
            _health,
            _speed,
            _level,
            _xp;

        private Monster _leader;
        private MonsterSpawner _spawner;
        private bool _isActive;
        private bool _isLeader;

        public void Init(string name, string type, int health, int speed, int level, int xp)
        {
            _name = name;
            _type = type;
            _health = health;
            _speed = speed;
            _level = level;
        }

        public void MakeLeader()
        {
            _leader = null;
            _isLeader = true;
        }


    }
}
