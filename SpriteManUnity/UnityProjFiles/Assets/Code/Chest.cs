using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
    {
        public class Chest : Item
        {
            public List<Item> goods;
            private string chestsize;
            public string rarity;
            public bool locked = true;
            private bool IDed;
            private ChestSpawner mySpawner;
            
            public Sprite CommonSprite,
                UncommonSprite,
                RareSprite,
                LegendarySprite;
            
            public void Awake()
            {
                print("Chest created");
            }

            public void Init(string size, string chestRarity, bool identified, ChestSpawner spawner)
            {
                chestsize = size;
                rarity = chestRarity;
                IDed = identified;
                mySpawner = spawner;
                itemName = rarity + " " + chestsize + " chest";

                // change the size of the sprite depending on chestsize value
                // TODO when assets are available, load different images
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
                
                switch (rarity)
                {
                    case "common": gameObject.GetComponent<SpriteRenderer>().sprite = CommonSprite;
                        locked = false;
                        break;
                    case "uncommon": gameObject.GetComponent<SpriteRenderer>().sprite = UncommonSprite;
                        break;
                    case "rare": gameObject.GetComponent<SpriteRenderer>().sprite = RareSprite;
                        break;
                    case "legendary": gameObject.GetComponent<SpriteRenderer>().sprite = LegendarySprite;
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

            //public void unlock()
            //{
            //    locked = false;
            //}

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

            public override void Use()
            {
                MasterManager masterMan = FindObjectOfType<MasterManager>();
                /// If player isn't in the vault, collect the chest
                if (masterMan.SceneMan.ActiveScene.name != "Vault")
                {
                    masterMan.BaseMan.PlayerVault.AddItem(this);
                    gameObject.transform.position = masterMan.transform.position;
                    print("moving chest");
                }
                ///Triggered if player is in the vault and the chest is not locked
                else if (!locked)
                {
                    foreach (Item item in goods)
                    {
                        if (item != null)
                            if (item is Resource)
                            {
                                item.Use();
                            }
                            else
                                TransferItem(item, masterMan.PlayerMan.Playerinv);
                                print("transferring items");
                    }
                    Destroy(gameObject);
                }
                else if (locked)
                {
                    int rarityint = (int)Enum.Parse(typeof(BaseKeys), rarity);
                    if (masterMan.BaseMan.BaseKeys[rarityint] > 0)
                    {
                        masterMan.BaseMan.BaseKeys[rarityint] -= 1;
                        locked = false;
                        Use();
                    }
                    else
                        print("Chest Locked Sucka");
                    //prompt user to either ID or Unlock the chest
                    //alternatively, IDing should occur automatically by the computer, so
                    //the only action necessary here is to Unlock the chest if the key is owned
                }
            }
        }
    }
