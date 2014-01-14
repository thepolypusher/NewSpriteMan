using UnityEngine;

namespace Assets.Code
{
    public class Bullet : MonoBehaviour
    {


        private bool right;
        private float bulletSpeed, bulletRange, bulletDamage, bulletAge = 0.0f;

        void Awake()
        {
            print("new bullet spawned omfg!");
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
                print("Bullet dying of old age");
            }
        }
        public void setAttribs(float gunspeed, float gunrange, float gundamage, bool isright)
        {
            bulletSpeed = gunspeed;
            bulletRange = gunrange;
            bulletDamage = gundamage;
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
                var newMonster = other.transform.parent.gameObject;
               // Monster monster = newMonster;

                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
}