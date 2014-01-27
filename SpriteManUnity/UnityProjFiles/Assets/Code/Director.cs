using UnityEngine;
using System.Collections;

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
        public float timer = 0;

        public void Awake()
        {
            _masterMan = FindObjectOfType<MasterManager>();
            //placeholder scale for maximum budget based on player level
            _maxBudget = _masterMan.PlayerMan.PlayerLevel * 1000;
            _currentBudget = _maxBudget / 4;
            _spendingThreshhold = _currentBudget/4; //lets the Director spend right away
        }

        public void Update()
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                _currentBudget += 1;
                timer = 0;
            }            
            if (!_isBuyingStuff && _currentBudget >= _spendingThreshhold)
            {
                StartCoroutine("SpendCoins");
            }

        }

        private IEnumerator SpendCoins()
        {
            _isBuyingStuff = true;
            yield return new WaitForSeconds(DirectorPulse);
            if (_currentBudget >= 0)
            {
                var SpawnList = _masterMan.SceneMan.GetActiveSpawners();
                //build a shopping list
                //pick something off the list
                int x = Random.Range(0, SpawnList.Count); //pick a random spawner to use
                SpawnList[x].SpawnMonster(DirectorMonster);
                _currentBudget -= DirectorMonster.Coins;
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
