/*
    purpose: variables and events class for planetary bodies and asteroidal objects
    usage: only used on planets and asteroids
*/

using UnityEngine;

public class StationObject : GeneralObject
{
    //override FixedUpdate to allow StationObject to add its own explosion effects
    override public void DerivedStart()
    {
        //load overloaded explosion types
        Explosions = new GameObject[1];
        Explosions = GameObject.FindGameObjectWithTag("Canvas").GetComponent<StationExplosionPrefabProvider>().Explosions;
    }

    //events
    private void Rotate()
    {
        //purpose: rotates the planetary body with the class's specified rotation speed and rotation direction


    }
}