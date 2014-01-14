using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject SpriteMan;



        void Start()
        {

        }

        void Update()
        {
            float xpos = SpriteMan.transform.position.x;
            float cameraxpos = gameObject.transform.position.x;
            gameObject.transform.position = new Vector3(xpos, SpriteMan.transform.position.y, -10f);
        }
    }
}