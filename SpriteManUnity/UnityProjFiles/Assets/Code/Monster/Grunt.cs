using UnityEngine;

namespace Assets.Code
{
    public class Grunt : MonsterAC
    {

        private MonsterSpawner _spawner;


        public void Update()
        {
            if (Health <= 0)
                Destroy(gameObject);
        }

        public override void AdditionalInit()
        {
            
        }

    }
}
