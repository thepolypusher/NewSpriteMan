using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code
{
    public class SceneManager : MonoBehaviour
    {
        public MonsterAC DebugMonster;
        public List<InteractByProximity> SceneInteractiveObjects = new List<InteractByProximity>();

        public int MonsterSpawnerActivationRange;
        private MasterManager _masterMan;
        public Scene ActiveScene;
        private Player player; 
        private List<ChestSpawner> SceneChests = new List<ChestSpawner>();
        public List<MonsterSpawner> AvailableMonsterSpawners = new List<MonsterSpawner>();
        private Camera MainCamera;
        private PlayerManager _playerMan;

        void Awake()
        {
            ActiveScene = FindObjectOfType<Scene>();
            MainCamera = FindObjectOfType<Camera>();
            player = FindObjectOfType<Player>();
            _masterMan = FindObjectOfType<MasterManager>();
            MonsterSpawner[] ts = ActiveScene.GetComponentsInChildren<MonsterSpawner>();
            foreach (MonsterSpawner spawner in ts)
            {
                AvailableMonsterSpawners.Add(spawner);
                //spawner.SpawnMonster(DebugMonster); //Debug action to spawn a monster in each spawnpoint in the level
            }
            GetActiveSpawners();

            ChestSpawner[] cs = ActiveScene.GetComponentsInChildren<ChestSpawner>();
            foreach (ChestSpawner chestspawner in cs)
            {
                SceneChests.Add(chestspawner);
                var newChest = _masterMan.LootMan.ConstructChest(chestspawner);
                chestspawner.Init(newChest);
            }
            
            InteractByProximity[] intobjs = FindObjectsOfType<InteractByProximity>();
            foreach (InteractByProximity intobj in intobjs)
                SceneInteractiveObjects.Add(intobj);

            player.transform.position = ActiveScene.PlayerStartPoint.position;
        }

        public void SpawnMonster(MonsterSpawner spawner, MonsterAC monster)
        {
            spawner.SpawnMonster(monster);
        }

        public void MonsterDied(MonsterAC monster)
        {
            int _chanceForLoot = _masterMan.LootMan.raritythresh;
            int _randomroll = UnityEngine.Random.Range(0, 10);
            Item newItem; 
            
            _masterMan.PlayerMan.AddXP(monster.Xp);
            _masterMan.Director.AddToBudget((monster.Coins*_masterMan.Director.RefundOnCoins) /100);

            if (_randomroll <= _chanceForLoot)
            {
                newItem = _masterMan.LootMan.ItemLootDrop();
                newItem = Instantiate(newItem, monster.transform.position, monster.transform.rotation) as Item;
            }
        }

        public List<MonsterSpawner> GetActiveSpawners()
        {
            //ActiveMonsterSpawners.Clear(); //initialize an empty list of active spawners
            List<MonsterSpawner> ActiveMonsterSpawners = new List<MonsterSpawner>();

            foreach(MonsterSpawner spawner in AvailableMonsterSpawners)
            {
                var distancetoplayer = Vector2.Distance(spawner.transform.position, player.transform.position);
                if (distancetoplayer <= MonsterSpawnerActivationRange)
                {
                    ActiveMonsterSpawners.Add(spawner);
                }
            }
            return ActiveMonsterSpawners;
        }


    }
}
