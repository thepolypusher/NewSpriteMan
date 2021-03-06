﻿using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Assets.Code
{
    public class LootManager : MonoBehaviour
    {
        private MasterManager _masterMan;
        public BaseManager _baseMan;

        public Chest chestPrefab;
        public LootTable lootTable;

        public int raritythresh = 8; // Increasing this value makes all loot more rare. 7= about 70% junk
        
        private void Awake()
        {
            _masterMan = FindObjectOfType<MasterManager>();
            _baseMan = _masterMan.BaseMan;
        }

        public Chest ConstructChest(ChestSpawner spawner)
        {
            string newChestSize = ChestSize();
            string newChestRarity = ChestRarity(newChestSize);
            int newChestSlots = GetChestSlots(newChestSize);
            bool isIdentified = ChestIsIdentified();
            var newChest = Instantiate(chestPrefab, spawner.transform.position, spawner.transform.rotation) as Chest;
            Debug.Assert(newChest != null, "newChest != null");
            newChest.Init(newChestSize, newChestRarity, isIdentified, spawner);
            FillChest(lootTable, newChest, newChestSlots, newChestRarity);
            return newChest;
        }

        public Item ItemLootDrop()
        {
            Item newItem;
            bool isdrop = true;
            int rarity = GetRarity(raritythresh);
            string raritystring = DropRarity(rarity);
            //if (raritystring != "nothing")
            //    return null;
            //else
                newItem = lootTable.GetItem(raritystring, isdrop);
            return newItem;
        }

        private string ChestSize()
        {
            //1-5 medium size. 6-8 large/small. 9-10 huge/tiny
            int size = UnityEngine.Random.Range(1, 11);
            int coin = UnityEngine.Random.Range(0, 2);
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
            if (x > 5)
                x = 5;
            return x;
        }

        private string DropRarity(int rarity)
        {
            string newrarity;
            switch (rarity)
            {
                case 1: newrarity = "nothing";
                    break;
                case 2: newrarity = "junk";
                    break;
                case 3: newrarity = "common";
                    break;
                case 4: newrarity = "uncommon";
                    break;
                case 5: newrarity = "rare";
                    break;
                default: throw new ArgumentException("X is greater than 5");
            }
            return newrarity;
        }

        private string ChestRarity(string chestsize)
        {
            //some code smell on this. Break into 2 methods, slots and rarity?
            //could argue there's not a great reason to separate the two.
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
                bool isdrop = false;
                Item newItem;
                newItem = lootTable.GetItem(rarity, isdrop);
                newchest.AddItem(newItem);
            }
        }

        private bool ChestIsIdentified()
        {
            bool id;
            int x = GetRarity(raritythresh);
            if (x <= 3)
                id = false;
            else
                id = true;
            return id;
        } 
    }
}
