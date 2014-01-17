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
            monstertype;
        public float //derived
            _health,
            _speed;
        
        public string MonsterState = "sleep";

        private int level,
            _xp;

        private MonsterSpawner _spawner;

        public void Start()
        {
        }

        public void Update()
        {
            if (_health <= 0)
                Destroy(gameObject);
        }

        private void MonsterBalancer(int level, string type) // takes all the initial values and derives health etc
        {
            float BalanceFudge = 1.0f;

            _health = level*100;
            switch (type)
            {
                case "brute": _health += 20 * level;
                    break;
                case "grunt": _health += 5 * level;
                    _speed += 1;
                    break;
                case "blade": _health += 1 * level;
                    _speed += 3;
                    break;
                default:
                    break;

            }
            
            _health *= BalanceFudge;
            _health *= 1.0f / UnityEngine.Random.Range(1, 11);
            _health += 7;
        }

        public void Init(int monsterlevel)
        {
            level = monsterlevel;
            MonsterBalancer(level, monstertype);

        }

        public void SubtractHealth(int amount)
        {
            _health -= amount;
        }

    }
}
