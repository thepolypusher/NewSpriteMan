using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Code
{
    public class PlayerManager : MonoBehaviour
    {
        private Player _player;
        private List<Chest> _vaultChests;
        public Container Playerinv;

        void Awake()
        {
            _player = FindObjectOfType<Player>();
            Playerinv = GetComponent<Container>();
        }

    }
}