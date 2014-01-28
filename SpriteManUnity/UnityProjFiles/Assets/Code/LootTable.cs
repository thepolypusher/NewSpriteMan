using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class LootTable : MonoBehaviour
    {
        //public Item resourceStub; // just some debug items to work with the loot tables
        //public Item gunStub;
        //public Item keyStub;

        public List<Item> junkTable = new List<Item>();
        public List<Item> commonTable = new List<Item>();
        public List<Item> uncommonTable = new List<Item>();
        public List<Item> rareTable = new List<Item>();
        public List<Item> legendaryTable = new List<Item>();
        public List<Item> dropTable = new List<Item>();
        
        public void Awake()
        {
            //debug adding some item stubs as a loot table
            //junkTable.Add(resourceStub);
            //commonTable.Add(resourceStub);
            //uncommonTable.Add(resourceStub);
            //rareTable.Add(resourceStub);
            //legendaryTable.Add(resourceStub);
        }

        public Item GetItem(string rarity, bool isDrop)
        {
            Item newItem;
            if (!isDrop)
            {
                switch (rarity)
                {
                    case "nothing": newItem = null;
                        print("No item result");
                        break;
                    case "junk": newItem = GetItemFromTable(junkTable);
                        break;
                    case "common": newItem = GetItemFromTable(commonTable);
                        break;
                    case "uncommon": newItem = GetItemFromTable(uncommonTable);
                        break;
                    case "rare": newItem = GetItemFromTable(rareTable);
                        break;
                    case "legendary": newItem = GetItemFromTable(legendaryTable);
                        break;
                    default: newItem = GetItemFromTable(junkTable);
                        Debug.Log("Defaulted, must have gotten invalid rarity");
                        break;
                }
            }
            else
                newItem = GetItemFromDropTable(rarity);
            return newItem;
        }

        private Item GetItemFromTable(List<Item> table)
        {
            Item newItem;
            int x = UnityEngine.Random.Range(0, table.Count);
            newItem = table[x];
            return newItem;
        }
        private Item GetItemFromDropTable(string rarity)
        {
            Item newItem;
            int x = UnityEngine.Random.Range(0, dropTable.Count);
            //print("GetItemFromDropTable random number is " + x);
            newItem = dropTable[x];
            return newItem;
        }
        
    }
}
