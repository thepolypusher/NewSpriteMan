using UnityEngine;

namespace Assets.Code
{
    public class Bullet : MonoBehaviour
    {


        private bool right;
        private float bulletSpeed, bulletRange, bulletAge = 0.0f;
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
            if (other.tag == "Player" || other == gameObject)
                return;
            if (other.tag == "Enemy")
            {
                Transform newMonstertrans = other.transform.parent;
                Monster newMonster = newMonstertrans.GetComponentInChildren<Monster>();
                newMonster.SubtractHealth(_bulletDamage);
                Destroy(gameObject);
                Debug.Log("Applying " + _bulletDamage + " to monster");
            }
            else
                Destroy(gameObject);
        }
    }
}