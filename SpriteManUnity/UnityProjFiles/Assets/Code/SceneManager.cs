using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code
{
    public class SceneManager : MonoBehaviour
    {
        public Monster DebugMonster;
        public List<InteractByProximity> SceneInteractiveObjects = new List<InteractByProximity>();

        private MasterManager _masterMan;
        public Scene ActiveScene;
        private Player player; 
        private List<ChestSpawner> SceneChests = new List<ChestSpawner>();
        public List<MonsterSpawner> AvailableMonsterSpawners = new List<MonsterSpawner>();
        public List<MonsterSpawner> ActiveMonsterSpawners = new List<MonsterSpawner>();
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
                spawner.SpawnMonster(DebugMonster);
            }

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

        public void SpawnMonster(MonsterSpawner spawner, Monster monster)
        {
            spawner.SpawnMonster(monster);
        }

        public void MonsterDied(MonsterAC monster)
        {
            int _chanceForLoot = _masterMan.LootMan.raritythresh;
            int _randomroll = UnityEngine.Random.Range(0, 10);
            Item newItem; 
            
            _masterMan.PlayerMan.AddXP(monster.Xp);
            _masterMan.Director.AddToBudget(monster.Xp);

            if (_randomroll <= _chanceForLoot)
            {
                newItem = _masterMan.LootMan.ItemLootDrop();
                if(newItem.GetType() == typeof(DroppedLoot))
                {
                    ;//how to give the item to the player. Had trouble getting Use() to give directly to the player
                }
            }
        }


    }
}
