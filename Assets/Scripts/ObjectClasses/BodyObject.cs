/*
    purpose: variables and events class for planetary bodies and asteroidal objects
    usage: only used on planets and asteroids
*/

using UnityEngine;

public enum Rotation { clockwise, anticlockwise }; //enumeration to allow change in direction in designer

public class BodyObject : GeneralObject
{
    public float GravimetricStrength = 1f; //gravimetric strength outputted by entity (used as a factoring variable)
    public float RotationSpeed = 0.01f; //speed of planetary rotation
    public Rotation OrbitRotation = Rotation.clockwise; //enumeration of rotation direction

    //override FixedUpdate to allow BodyObject to rotate
    override public void DerivedFixedUpdate() { Rotate(); }

    //events
    private void Rotate()
    {
        //purpose: rotates the planet naturally
        //usage: used in FixedUpdate()

        if (OrbitRotation == Rotation.clockwise) transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        else transform.Rotate(Vector3.down, RotationSpeed * Time.deltaTime);
    }

    override public float GetSize() { return GetComponent<MeshFilter>().mesh.bounds.extents.x * GetComponent<Transform>().localScale.x; }
}