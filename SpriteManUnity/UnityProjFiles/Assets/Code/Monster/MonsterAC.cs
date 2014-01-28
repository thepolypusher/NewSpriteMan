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
            MoveSpeed,
            AttackDamage;

        public float AttackRateOfFire,
            AttackBulletSpeed,
            AttackRange;// these should be in Gun, but its better to define them in the monster...

        public Gun MainAttackGun;
        public Transform MainAttackOrigin;

        public int Health { get; private set; }

        private bool facingRight = true; //not sure how to control this. Go by vector of last movement force in Update()?
        private bool targetIsLeftOfMe = true;

        private MasterManager _masterMan;
        private Transform target;




        public void Awake()
        {
            _masterMan = FindObjectOfType<MasterManager>();
            MainAttackGun.MonsterGunInit(AttackRateOfFire, AttackDamage, AttackRange, AttackBulletSpeed, MainAttackOrigin);
            if (gameObject.tag == "Untagged") //maintenance to make sure I get set up as an enemy
                gameObject.tag = "Enemy";
            target = FindObjectOfType<Player>().transform;
        }

        public void FixedUpdate()
        {
            var targetdDistance = Vector2.Distance(target.position, gameObject.transform.position);
            determineFacing();
            if (targetdDistance > AttackRange)
            {
                MoveTowardPlayer();
            }
            else if (targetdDistance < AttackRange)
            {
                MainAttack();
            }
        }

        public void Init(int monsterlevel)
        {
            Level = monsterlevel;
            //MonsterBalancer(Level);
            Xp = monsterlevel * 100;
            Health = 100 * Level;
            AdditionalInit();
        }

        //a place to put any additional code that needs to be initialized for the implementing class
        public abstract void AdditionalInit();

        private void determineFacing()
        {
            //get the positive or negative value of the local position of the target relative to self
            var targetRelativeDirection = gameObject.transform.InverseTransformPoint(target.position).x;
            bool targetIsLeft;

            //convert that to a bool (Unneccessary really)
            if (targetRelativeDirection < 0)
                targetIsLeft = true;
            else
                targetIsLeft = false;
            //Flip if I'm facing the wrong way
            if (targetIsLeft && facingRight)
            {
                Flip();
            }
            else if (targetIsLeft && !facingRight)
                Flip();
        }

        public void Heal(int amount)
        {
            Health += amount;
        }

        public void Damage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
                Die();
        }

        public int GetHealth()
        {
            return Health;
        }

        public void Die()
        {
            _masterMan.SceneMan.MonsterDied(this);
            Destroy(gameObject);
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

        public void MoveTowardPlayer()
        {
            rigidbody2D.velocity = new Vector2(MoveSpeed, rigidbody2D.velocity.y);
        }

        public void Flip()
        {
            Vector3 theScale = transform.localScale;
            facingRight = !facingRight;
            theScale.x *= -1;
            transform.localScale = theScale;
            MoveSpeed *= -1;
        }

    }

}