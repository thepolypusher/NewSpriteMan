using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code
{
    public class SceneManager : MonoBehaviour
    {
        public LootManager LootMan;
        public Monster DebugMonster;
        public List<ChestSpawner> SceneChests = new List<ChestSpawner>();
        public List<MonsterSpawner> SceneMonsterSpawners = new List<MonsterSpawner>();
        public Scene ActiveScene;
        

        public void Awake()
        {
            MonsterSpawner[] ts = gameObject.GetComponentsInChildren<MonsterSpawner>();
            foreach (MonsterSpawner spawner in ts)
            {
                SceneMonsterSpawners.Add(spawner);
            }


            foreach (MonsterSpawner spawner in SceneMonsterSpawners)
            {
                spawner.SpawnMonster(DebugMonster);
            }

            ChestSpawner[] cs = gameObject.GetComponentsInChildren<ChestSpawner>();
            foreach (ChestSpawner chestspawner in cs)
            {
                SceneChests.Add(chestspawner);
            }

            foreach (ChestSpawner newchestspawner in SceneChests)
            {
                if (!newchestspawner.hasChest)
                {
                    var newChest = LootMan.ConstructChest(newchestspawner);
                    newchestspawner.Init(newChest);
                }
            }

        }

        public void SpawnMonster(MonsterSpawner spawner, Monster monster)
        {
            spawner.SpawnMonster(monster);
        }

    }
}
