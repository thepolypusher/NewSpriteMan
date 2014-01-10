using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Code
{
    public class LootManager : MonoBehaviour
    {
        public MasterManager Master;
        public Chest chestPrefab;
        public LootTable lootTable;
        //public List<Chest> sceneChests = new List<Chest>();

        private int raritythresh = 8; // Increasing this value makes all loot more rare. 7= about 70% junk
        
        //public method for a chest spawner to request a chest

        private void Start()
        {
            //ConstructChest();
        }

        public Chest ConstructChest(ChestSpawner spawner)
        {
            string newChestSize = ChestSize();
            Debug.Log(newChestSize);
            string newChestRarity = ChestRarity(newChestSize);
            Debug.Log(newChestRarity);
            int newChestSlots = GetChestSlots(newChestSize);
            Debug.Log(newChestSlots + " slots");
            bool isIdentified = ChestIsIdentified();
            Debug.Log("Identified?: " + isIdentified);
            var newChest = Instantiate(chestPrefab, spawner.transform.position, spawner.transform.rotation) as Chest;
            newChest.Init(newChestSize, newChestRarity, isIdentified);
            FillChest(lootTable, newChest, newChestSlots, newChestRarity);
            return newChest;
        }

        private string ChestSize()
        {
            //1-5 medium size. 6-8 large/small. 9-10 huge/tiny
            int size = UnityEngine.Random.Range(1, 11);
            int coin = UnityEngine.Random.Range(0,2);
            if (size <= 5)
                return "medium";
            else if (size <= 8)
                if (coin == 0)
                    return "small";
                else
                    return "large";
            else
                if (coin == 0)
                    return "tiny";
                else
                    return "huge";
        }
        
        private int GetRarity(int raritythresh)
        {
            int y = raritythresh;
            int x = 1;
            while (y >= raritythresh)
            {
                y = UnityEngine.Random.Range(1, 11);
                if (y >= raritythresh)
                    x += 1;
            }
            return x;
        }

        private string ChestRarity(string chestsize)
        {
            string chestrarity;
            int x = GetRarity(raritythresh);

            if (chestsize == "tiny" && x < 3)
                x = 3;
            else if (chestsize == "huge" && x >= 4)
                x = 3;
            else if (chestsize == "small" && x < 2)
                x = 2;
            if (x > 5)
                x = 5;
            switch (x)
            {
                case 1: chestrarity = "common"; // no junk chests
                    break;
                case 2: chestrarity = "common";
                    break;
                case 3: chestrarity = "uncommon";
                    break;
                case 4: chestrarity = "rare";
                    break;
                case 5: chestrarity = "legendary";
                    break;
                default: throw new ArgumentException("X is greater than 5");
            }
            return chestrarity;
        }

        private int GetChestSlots(string chestsize)
        {
            int slots;
            switch (chestsize)
            {
                case "tiny": slots = 0;
                    break;
                case "small": slots = 1;
                    break;
                case "medium": slots = 2;
                    break;
                case "large": slots = 4;
                    break;
                case "huge": slots = 6;
                    break;
                default: throw new ArgumentException("Invalid Chest size" + chestsize);
            }
            return slots;
        }

        private void FillChest(LootTable lootTable, Chest newchest, int slots, string rarity)
        {
            for (int x = 0; x <= slots; x++)
            {
                Item newItem;
                newItem = lootTable.GetItem(rarity);
                Debug.Log(newItem);
                newchest.AddItem(newItem);
            }
        }

        private bool ChestIsIdentified()
        {
            bool id;
            int x = GetRarity(raritythresh);
            if (x <= 4)
                id = true;
            else
                id = false;
            return id;
        }
    }
}
