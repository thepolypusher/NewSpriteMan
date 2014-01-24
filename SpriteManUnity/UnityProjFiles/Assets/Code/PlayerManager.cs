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
        public int PlayerLevel;

        public int PlayerHealth,
            PlayerMoney;

        public int _xp;

        void Awake()
        {
            _player = FindObjectOfType<Player>();
            //Playerinv = GetComponent<Container>();
        }

        public void AddXP(int xpval)
        {
            _xp += xpval;
        }

    }
}