using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code
{
    public class SceneManager : MonoBehaviour
    {
        public LootManager lootMan;
        public List<ChestSpawner> sceneChests = new List<ChestSpawner>();
        public List<MonsterSpawner> sceneMonsterSpawners = new List<MonsterSpawner>();

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
        }

        public void SpawnMonster(MonsterSpawner spawner, Monster monster)
        {
            spawner.SpawnMonster(monster);
        }

    }
}
