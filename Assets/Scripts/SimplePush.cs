/// <summary>
/// PLACEHOLDER MOVEMENT script
/// </summary>
/// 
using UnityEngine;

public class SimplePush : MonoBehaviour
{
    public float fltVelocity = 1000f;
    public float fltStepper = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Vector3 vctMovement = new Vector3(fltStepper, 0.0f, 0.0f);

        rb.AddForce(vctMovement * fltVelocity);
	}
}