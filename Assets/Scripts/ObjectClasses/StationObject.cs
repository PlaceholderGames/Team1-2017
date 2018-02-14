/*
    purpose: variables and events class for planetary bodies and asteroidal objects
    usage: only used on planets and asteroids
*/

using UnityEditor;
using UnityEngine;

public class StationObject : GeneralObject
{
    //override FixedUpdate to allow StationObject to add its own explosion effects
    override public void DerivedStart()
    {
        //load overloaded explosion types
        Explosions[0] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/ExplosionLarge01a.prefab", typeof(GameObject)) as GameObject;
        Explosions[1] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/ExplosionLarge01b.prefab", typeof(GameObject)) as GameObject;
        Explosions[2] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/ExplosionLarge01c.prefab", typeof(GameObject)) as GameObject;
        Explosions[3] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/ExplosionLarge02.prefab", typeof(GameObject)) as GameObject;
    }

    //events
    private void Rotate()
    {
        //purpose: rotates the planetary body with the class's specified rotation speed and rotation direction


    }
}