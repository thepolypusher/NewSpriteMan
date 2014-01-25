using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class ResourceJetFuel : Resource
    {
        public override void Use()
        {
            PlayerManager myPlayer = FindObjectOfType<PlayerManager>();
            if (myPlayer._currentJetFuel + Quantity >= myPlayer.MaxJetfuel)
                myPlayer._currentJetFuel = myPlayer.MaxJetfuel;
            else
            {
                myPlayer._currentJetFuel += Quantity;
            }
            print("trying to add to jetfuel");
            Destroy(gameObject);
        }
    }
}