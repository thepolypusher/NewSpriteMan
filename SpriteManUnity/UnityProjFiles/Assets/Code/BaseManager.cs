using UnityEngine;
using System.Collections;
using System;

namespace Assets.Code
{

    public class BaseManager : MonoBehaviour
    {
        //public int[] Resources = new int[Enum.GetNames(typeof(BaseResources)).Length];
        public int[] Resources;
        public int[] BaseKeys;

        public Container PlayerVault;

        public void Awake()
        {
            Resources = new int[Enum.GetNames(typeof(BaseResources)).Length];
            BaseKeys = new int[Enum.GetNames(typeof(BaseKeys)).Length];
        }
    }
}