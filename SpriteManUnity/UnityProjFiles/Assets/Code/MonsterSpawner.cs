using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class MonsterSpawner : MonoBehaviour
    {
        public bool is_guarded = false;
        public ArrayList flags;

        public void Awake()
        {
            //find the scene manager
            //find the active scene
            //add self to chest list in scene
        }

        private void SpawnMonster(Monster newmonster)
        {
            newmonster = Instantiate(newmonster, transform.position, transform.rotation) as Monster;
        }
    }
}
