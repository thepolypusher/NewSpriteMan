using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code
    {
        public class Chest : MonoBehaviour
        {
            public List<Item> goods;

            private string chestsize;
            public string rarity;
            private bool locked = true;
            private bool IDed;
            private ChestSpawner mySpawner;
            public int chestID;

            public void Start()
            {
                if (chestsize == "huge")
                    gameObject.transform.localScale = new Vector3(4f,4f, 1);
                if (chestsize == "large")
                    gameObject.transform.localScale = new Vector3(3f, 3f, 1);
                if (chestsize == "medium")
                    gameObject.transform.localScale = new Vector3(2f, 2f, 1);
                if (chestsize == "small")
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1);
                if (chestsize == "tiny")
                    gameObject.transform.localScale = new Vector3(.5f, .5f, 1);
            }

            public void Init(string size, string chestRarity, bool identified, ChestSpawner spawner)
            {
                chestsize = size;
                rarity = chestRarity;
                IDed = identified;
                mySpawner = spawner;
            }

            public void AddItem(Item newItem)
            {
                goods.Add(newItem);
            }

            public void setIDed(bool ided)
            {
                IDed = ided;
            }

            public void unlock()
            {
                locked = false;
            }

            public void ShowItems()
            {
                if (!IDed)
                    return;
                else
                {
                    foreach (Item i in goods)
                    {
                        //temp code to show the items
                    }
                }
            }

            ///method to transfer items if legal
            public void GetChestItems(GameObject container)
            {
                if (locked) 
                {
                    Debug.Log("Something tried to open the locked chest: " + gameObject.name);
                    return;
                }
                else
                {
                    //for each item in the goods list, copy it to the container, erase the goods list and destroy the chest
                }
            }
        }
    }
