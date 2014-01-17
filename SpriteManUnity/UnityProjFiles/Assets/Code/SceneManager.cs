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
        private List<MonsterSpawner> SceneMonsterSpawners = new List<MonsterSpawner>();

        void Awake()
        {
            ActiveScene = FindObjectOfType<Scene>();
            player = FindObjectOfType<Player>();
            _masterMan = FindObjectOfType<MasterManager>();
            MonsterSpawner[] ts = ActiveScene.GetComponentsInChildren<MonsterSpawner>();
            foreach (MonsterSpawner spawner in ts)
            {
                SceneMonsterSpawners.Add(spawner);
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
    }
}
