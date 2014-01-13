using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code
{
    public class SceneManager : MonoBehaviour
    {
        public LootManager lootMan;
        public Monster debugMonster;
        public List<ChestSpawner> sceneChests = new List<ChestSpawner>();
        public List<MonsterSpawner> sceneMonsterSpawners = new List<MonsterSpawner>();
        public Scene activeScene;
        
        
        

        public void Awake()
        {
            foreach (ChestSpawner spawner in sceneChests)
            {
                if (!spawner.hasChest)
                {
                    var newChest = lootMan.ConstructChest(spawner);
                    spawner.Init(newChest);
                }
            }

            //debug monster spawner, just puts a bunch of dummies in the scene
            foreach (MonsterSpawner spawner in sceneMonsterSpawners)
            {
                SpawnMonster(spawner, debugMonster);
            }
        }

        public void SpawnMonster(MonsterSpawner spawner, Monster monster)
        {
            spawner.SpawnMonster(monster);
        }

    }
}
