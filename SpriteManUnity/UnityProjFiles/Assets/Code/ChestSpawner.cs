using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code
{
    public class ChestSpawner : MonoBehaviour
    {
        public Chest myChest;
        public bool hasChest = false;
        //public bool is_guarded = false;
        //public ArrayList flags;
        //private Chest chest;

        public void Awake()
        {
            //find the scene manager
            //find the active scene
            //add self to chest list in scene
        }

        public void Init(Chest newChest)
        {
            myChest = newChest;
            hasChest = true;
        }

    }
}
