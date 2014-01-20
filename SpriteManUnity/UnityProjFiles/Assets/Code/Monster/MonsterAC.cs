using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public abstract class MonsterAC : MonoBehaviour
    {

        public string Name;

        public int Coins,
            Xp,
            Level,
            Speed,
            AttackDamage;

        public float AttackRateOfFire,
            AttackRange;// these should be in Gun, but its better to define them in the monster...

        public Gun MainAttackGun;
        public Transform MainAttackOrigin;

        public int Health { get; private set; }

        private bool facingRight; //not sure how to control this. Go by vector of last movement force in Update()?

        private MasterManager _masterMan;





        public void Awake()
        {
            _masterMan = FindObjectOfType<MasterManager>();
            MainAttackGun.MonsterGunInit(AttackRateOfFire, AttackDamage, AttackRange, MainAttackOrigin);
        }

        public void Init()
        {
            
            AdditionalInit();
        }

        //a place to put any additional code that needs to be initialized for the implementing class
        public abstract void AdditionalInit();

        public void Heal(int amount)
        {
            Health += amount;
        }

        public void Damage(int amount)
        {
            Health -= amount;
        }

        public int GetHealth()
        {
            return Health;
        }

        public void OnDestroy()
        {
            _masterMan.SceneMan.MonsterDied(this);
        }

        public void Guard(Vector2 point)
        {
            //station the monster somewhere?
        }

        public void MainAttack()
        {
            MainAttackGun.TryShoot(facingRight);
        }

        public void Retreat()
        {
            
        }

        public void FindTarget()
        {
            
        }

    }

}