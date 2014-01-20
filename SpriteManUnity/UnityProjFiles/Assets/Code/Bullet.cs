using UnityEngine;

namespace Assets.Code
{
    public class Bullet : MonoBehaviour
    {


        private bool right;
        private float bulletSpeed, bulletRange, bulletAge;
        private int _bulletDamage;

        void Awake()
        {
        }

        void FixedUpdate()
        {
            if (right)
            {
                transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(-bulletSpeed * Time.deltaTime, 0, 0);

            }
        }
        void Update()
        {
            bulletAge += Time.deltaTime;
            if (bulletRange <= bulletAge)
            {
                Destroy(gameObject);
            }
        }
        public void setAttribs(float gunspeed, float gunrange, int gundamage, bool isright)
        {
            bulletSpeed = gunspeed;
            bulletRange = gunrange;
            _bulletDamage = gundamage;
            right = isright;
            if (!right)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            // this could more elegantly filter out the things I dont care about hitting. Right now
            //level geometry has to be added as "Geo" to hit it
            if (other.tag == "Player")
                return;
            if (other.tag == "Geo")
                Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                MonsterAC newMonster = other.GetComponent<MonsterAC>();
                newMonster.Damage(_bulletDamage);
                Destroy(gameObject);
            }
            else //chests and other colliders I don't care about
                return;
        }
    }
}