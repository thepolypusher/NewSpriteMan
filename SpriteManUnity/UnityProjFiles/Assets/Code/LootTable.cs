using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class LootTable : MonoBehaviour
    {
        public Item resourceStub; // just some debug items to work with the loot tables
        public Item gunStub;
        public Item keyStub;

        private List<Item> junkTable = new List<Item>();
        private List<Item> commonTable = new List<Item>();
        private List<Item> uncommonTable = new List<Item>();
        private List<Item> rareTable = new List<Item>();
        private List<Item> legendaryTable = new List<Item>();
        
        public void Awake()
        {
            //debug adding some item stubs as a loot table
            junkTable.Add(resourceStub);
            commonTable.Add(resourceStub);
            uncommonTable.Add(resourceStub);
            rareTable.Add(resourceStub);
            legendaryTable.Add(resourceStub);
        }

        // Gets an item from a table

        public Item GetItem(string rarity)
        {
            Item newItem;
            switch (rarity)
            {
                case "junk": newItem = GetItemFromTable(junkTable);
                    break;
                case "common": newItem = GetItemFromTable(commonTable);
                    break;
                case "uncommon" : newItem = GetItemFromTable(uncommonTable);
                    break;
                case "rare": newItem = GetItemFromTable(rareTable);
                    break;
                case "legendary": newItem = GetItemFromTable(legendaryTable);
                    break;
                default: newItem = GetItemFromTable(junkTable);
                    Debug.Log("Defaulted, must have gotten invalid rarity");
                    break;
            }
            return newItem;
        }

        private Item GetItemFromTable(List<Item> table)
        {
            Item newItem;
            int x = UnityEngine.Random.Range(0, table.Count);
            newItem = table[x];
            return newItem;
        }


        
    }
}
