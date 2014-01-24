using UnityEngine;

namespace Assets.Code
{
    public class Director : MonoBehaviour
    {
        public float DirectorFudge = 1.0f;
        public int DirectorPulse;
        public int RefundOnCoins; //the % of coins refunded to director when a monster dies

        public MonsterAC DirectorMonster;
        
        public int _currentBudget;
        private int _maxBudget;
        private MasterManager _masterMan;
        public  int _spendingThreshhold;
        public bool _isBuyingStuff = false;

        public void Awake()
        {
            _masterMan = FindObjectOfType<MasterManager>();
            //placeholder scale for maximum budget based on player level
            _maxBudget = _masterMan.PlayerMan.PlayerLevel * 1000;
            _currentBudget = _maxBudget / 4;
            _spendingThreshhold = _currentBudget; //lets the Director spend right away
        }

        public void Update()
        {
            if (!_isBuyingStuff && _currentBudget >= _spendingThreshhold)
            {
                SpendCoins();
                _isBuyingStuff = true;
            }
        }

        private void SpendCoins()
        {
            while (_currentBudget >= 0)
            {
                float timer = Time.deltaTime;
                var SpawnList = _masterMan.SceneMan.GetActiveSpawners();
                //build a shopping list
                //pick something off the list
                int x = Random.Range(0, SpawnList.Count); //pick a random spawner to use
                SpawnList[x].SpawnMonster(DirectorMonster);
                _currentBudget -= DirectorMonster.Coins;
                Debug.Log("Spwaning a Monster!");
                while (timer < 1)
                    return;
            }
            _isBuyingStuff = false;
        }




        public void AddToBudget(int amount)
        {
            if (_currentBudget + amount <= _maxBudget)
            {
                float newBudgetAmount = _currentBudget;
                newBudgetAmount += amount * DirectorFudge;
                _currentBudget = (int)newBudgetAmount;
            }
            else
                _currentBudget = _maxBudget;
        }
    }
}
