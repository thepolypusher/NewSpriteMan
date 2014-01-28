using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class ResourceDropBase : Resource
    {
        public BaseResources ResourceType;
        private MasterManager MasterMan;
        
        public void Start()
        {
        }

        public override void Use()
        {
            MasterMan = FindObjectOfType<MasterManager>();
            MasterMan.BaseMan.Resources[(int)ResourceType] += Quantity;
            print("Player got " + Quantity + " of " + ResourceType);
            //Destroy(gameObject);
        }
    }
}