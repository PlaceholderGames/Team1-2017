/// <summary>
/// PLACEHOLDER MOVEMENT script
/// </summary>
/// 
using UnityEngine;

public class SimplePush : MonoBehaviour
{
    public float fltVelocity = 1000f;
    public float fltStepper = 10f;
    public Gravimetrics gv;

    void FixedUpdate()
    {
        Vector3 vctMovement = new Vector3(fltStepper, 0.0f, 0.0f);
        Vector3 vctAttraction = gv.GetMovementGravity();
        GetComponent<Rigidbody>().AddForce((vctMovement + vctAttraction) * fltVelocity);
	}
}