using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code
{
    public class SceneManager : MonoBehaviour
    {
        public LootManager lootMan;
        public List<ChestSpawner> sceneChests = new List<ChestSpawner>();

        public void LateUpdate()
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



    }
}
