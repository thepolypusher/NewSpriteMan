using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class Gun : MonoBehaviour
    {
        public float RateOfFire,
            GunRange,
            BulletSpeed;
        public int BulletDamage;
        public Transform GunBarrel;
        public Bullet bullet;
        public bool shotright;


        private float _time = 0f;
        private float _lastshottime = 0f;

        void Start()
        {
            _time = RateOfFire;
        }

        void Update()
        {
            _time += Time.deltaTime;
        }

        public void TryShoot(bool right)
        {
            //if the difference between last shot and new shot is greater than Rate of Fire, fire with the correct facing
            if (_time - _lastshottime >= RateOfFire)
            {
                shotright = right;


                var newBullet = Instantiate(bullet, GunBarrel.transform.position, GunBarrel.transform.rotation) as Bullet;
                newBullet.setAttribs(BulletSpeed, GunRange, BulletDamage, right);

                _lastshottime = _time;
            }
        }

    }
}