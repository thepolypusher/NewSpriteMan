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
            name;
            //type;
        public int //derived
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
            MonsterBalancer(level, _isLeader);
        }

        public void Update()
        {
            if (_health <= 0)
                Destroy(gameObject);
        }

        private void MonsterBalancer(int level, bool isLeader) // takes all the initial values and derives health etc
        {
            _health = level*100;
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

        public void SubtractHealth(int amount)
        {
            _health -= amount;
            Debug.Log("I've been shot!");
        }

    }
}
