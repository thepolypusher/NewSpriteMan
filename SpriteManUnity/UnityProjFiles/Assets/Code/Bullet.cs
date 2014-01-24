using UnityEngine;

namespace Assets.Code
{
    public class Bullet : MonoBehaviour
    {


        public bool right;
        public float bulletSpeed, bulletRange, bulletAge;
        public int _bulletDamage;
        public bool _playerBullet;

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
        public void setAttribs(float gunspeed, float gunrange, int gundamage, bool isright, bool plyrBullet)
        {
            bulletSpeed = gunspeed;
            bulletRange = gunrange;
            _bulletDamage = gundamage;
            right = isright;
            _playerBullet = plyrBullet;
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
            if (_playerBullet)
            {
                if (other.tag == "Player")
                    return;
                if (other.tag == "Enemy")
                {
                    Debug.Log("hit by bullet");
                    MonsterAC newMonster = other.GetComponent<MonsterAC>();
                    newMonster.Damage(_bulletDamage);
                    Destroy(gameObject);
                }
                else
                    return;
            }
            else
            {
                if (other.tag == "Enemy")
                    return;
                if (other.tag == "Player")
                {
                    Debug.Log("Hit a player");
                    Destroy(gameObject);
                }
                else
                    return;
            }
            if (other.tag == "Geo")
                Destroy(gameObject);

            else //chests and other colliders I don't care about
                return;
        }
    }
}