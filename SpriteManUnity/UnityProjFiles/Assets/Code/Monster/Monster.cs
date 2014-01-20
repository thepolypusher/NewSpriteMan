using UnityEngine;

namespace Assets.Code
{
    public class Monster : MonoBehaviour
    {
        public string
            name,
            monstertype;
        private float //derived
            _health,
            _speed;

        private MasterManager _masterMan;
        
        public string MonsterState = "sleep";

        public int level,
            _xp;

        private MonsterSpawner _spawner;

        public void Awake()
        {
            _masterMan = FindObjectOfType<MasterManager>();
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
            _xp = monsterlevel * 100;
        }

        public void SubtractHealth(int amount)
        {
            _health -= amount;
        }

        //public void OnDestroy()
        //{
        //    _masterMan.SceneMan.MonsterDied(this);
            
        //    //_masterMan.PlayerMan.AddXP(_xp);
        //    //print("I'm destroyed. Giving " + _xp + " xp");
        //    //Item newItem = _masterMan.LootMan.ItemLootDrop();
        //    //if (newItem != null)
        //    //    newItem.Use();                
        //}
    }
}
