using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class DroppedLoot : Item
    {
        private MasterManager _masterMan;
        private Container _playerInv;
        private int _quantity;
        public string DroppedItemType;

        void Awake()
        {
            _playerInv = _masterMan.GetComponent<Container>();
            //if (DroppedItemType == "money") // convert to switch statement when there are more types for item init
            //{
            //    _quantity = UnityEngine.Random.Range(10, 50); // placeholder money generating code
            //    _masterMan.PlayerMan.PlayerMoney += _quantity;
            //    print("adding some money");
            //}
            Use();
        }
        
        public override void Use()
        {
            //if (DroppedItemType == "money") // convert to switch statement when there are more types for item use
            //    ;
            //else
            //    ;//_masterMan.PlayerMan.Playerinv.AddItem(this);
        }
    }
}