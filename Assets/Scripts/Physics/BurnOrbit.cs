/*
    purpose: enables burn effect is probe is close to planet
    usage: for probes
*/

using UnityEngine;

namespace Assets.Scripts.Physics
{
    public class BurnOrbit : MonoBehaviour
    {
        public int burnBound = 0; //bounds for when the probe should burn inside
        public GameObject objToBurnIn; //object that the probe burns up in (singular object for demo)
        public GameObject particles; //reference to particles

        void FixedUpdate()
        {
            //calculate relative distance between probe and body
            Vector3 vctDirection = objToBurnIn.GetComponent<Rigidbody>().position - GetComponent<ProbeVariables>().GetPosition();
            float fltDistance = vctDirection.magnitude;

            //decide whether burn particles should be enabled/decided
            if (fltDistance > burnBound) particles.GetComponent<ParticleSystem>().Stop();
            else particles.GetComponent<ParticleSystem>().Play();
        }
    }
}
