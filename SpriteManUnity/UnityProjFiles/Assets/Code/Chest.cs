﻿using System;
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

            private SpriteRenderer spriterend;

            public Sprite defaultSprite;
            public Sprite CommonSprite,
                UncommonSprite,
                RareSprite,
                LegendarySprite;
            
            public void Awake()
            {
                spriterend = gameObject.GetComponent<SpriteRenderer>();
                defaultSprite = spriterend.sprite;
                switch (rarity)
                {
                    case "common": defaultSprite = CommonSprite;
                        break;
                    case "uncommon": defaultSprite = UncommonSprite;
                        break;
                    case "rare": defaultSprite = RareSprite;
                        break;
                    case "legendary": defaultSprite = LegendarySprite;
                        break;
                    default:
                        break;
                }
            }

            public void Init(string size, string chestRarity, bool identified, ChestSpawner spawner)
            {
                chestsize = size;
                rarity = chestRarity;
                IDed = identified;
                mySpawner = spawner;

                switch (chestsize)
                {
                    case "huge": gameObject.transform.localScale = new Vector3(4f, 4f, 1);
                        break;
                    case "large": gameObject.transform.localScale = new Vector3(3f, 3f, 1);
                        break;
                    case "medium": gameObject.transform.localScale = new Vector3(2f, 2f, 1);
                        break;
                    case "small": gameObject.transform.localScale = new Vector3(1f, 1f, 1);
                        break;
                    case "tiny": gameObject.transform.localScale = new Vector3(.5f, .5f, 1);
                        break;
                    default:
                        break;
                }

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
