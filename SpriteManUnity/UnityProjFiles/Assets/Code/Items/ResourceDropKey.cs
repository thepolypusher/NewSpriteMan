using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class ResourceDropKey : Resource
    {
        public BaseKeys KeyType;
        private LootManager LootMan;
        
        public void Awake()
        {
        }

        public override void Use()
        {
            Quantity = 1;
            LootMan = FindObjectOfType<LootManager>();
            LootMan._baseMan.BaseKeys[(int)KeyType] += Quantity; 
            print("Player got " + Quantity + " " + KeyType + " key");
            //Destroy(gameObject);
        }
    }
}