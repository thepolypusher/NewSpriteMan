using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code
    {
        public class Chest : MonoBehaviour
        {
            public string chestsize;
            public string rarity;
            public bool locked = true;
            public bool IDed;
            public List<Item> goods;

            public void Start()
            {
            }

            public void Init(string size, string chestRarity, bool identified)
            {
                chestsize = size;
                rarity = chestRarity;
                IDed = identified;
            }

            public void AddItem(Item newItem)
            {
                goods.Add(newItem);
                Debug.Log("Item " + newItem + "added to chest");
            }

        }
    }
