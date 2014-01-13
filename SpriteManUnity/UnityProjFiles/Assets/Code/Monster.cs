using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code
{
    public class Monster : MonoBehaviour
    {
        public string 
            name,
            type;
        private int //derived
            _health,
            _speed;


        private int level,
            _xp;

        private Monster _leader;
        private MonsterSpawner _spawner;
        private bool _isActive;
        private bool _isLeader;

        public void Start()
        {
            MonsterBalancer(level, type, _isLeader);
        }

        private void MonsterBalancer(int level, string type, bool isLeader) // takes all the initial values and derives health etc
        {

        }

        public void Init(int monsterlevel, bool isLeader)
        {
            if (isLeader)
                MakeLeader();

            level = monsterlevel;
        }

        public void MakeLeader()
        {
            _leader = null;
            _isLeader = true;
        }


    }
}
