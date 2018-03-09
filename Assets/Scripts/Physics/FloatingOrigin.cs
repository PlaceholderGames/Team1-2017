/*
	purpose: ensures the camera does not exceed floating point limitation-emposed bounds by moving the world around the camera
	usage: attached to camera
    based on: http://wiki.unity3d.com/index.php/Floating_Origin
*/

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float threshold = 1000.0f;
    public float physicsThreshold = 10000.0f; //0 disables script
    public float defaultSleepThreshold = 0.14f;
    ParticleSystem.Particle[] parts = null;

    void LateUpdate()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.y = 0f;

        if (cameraPosition.magnitude > threshold)
        {
            //transform position of objects relative to camera
            Object[] objects = FindObjectsOfType(typeof(Transform));
            foreach (Object o in objects)
            {
                Transform t = (Transform)o;
                if (t.parent == null) t.position -= cameraPosition;
            }

            //transform position of particles relative to camera
            objects = FindObjectsOfType(typeof(ParticleSystem));
            foreach (Object o in objects)
            {
                ParticleSystem sys = (ParticleSystem)o; //create local ParticleSystem instance
                if (sys.main.simulationSpace != ParticleSystemSimulationSpace.World) continue;

                //get number of particles needed to be altered
                int particlesNeeded = sys.main.maxParticles; 
                if (particlesNeeded <= 0) continue; //exit method if no particles

                //get status of particle system
                bool wasPaused = sys.isPaused;
                bool wasPlaying = sys.isPlaying;
                if (!wasPaused) sys.Pause(); //pause particle system
                
                if (parts == null || parts.Length < particlesNeeded) parts = new ParticleSystem.Particle[particlesNeeded]; //create array of all particles
                int num = sys.GetParticles(parts);
                for (int i = 0; i < num; i++) parts[i].position -= cameraPosition; //transform particle
                sys.SetParticles(parts, num); //set altered particel position
                if (wasPlaying) sys.Play(); //resume particle system
            }

            if (physicsThreshold > 0f)
            {
                float physicsThreshold2 = physicsThreshold * physicsThreshold; //simplify check on threshold
                objects = FindObjectsOfType(typeof(Rigidbody));
                foreach (Object o in objects)
                {
                    Rigidbody r = (Rigidbody)o;
                    if (r.gameObject.transform.position.sqrMagnitude > physicsThreshold2) r.sleepThreshold = float.MaxValue;
                    else r.sleepThreshold = defaultSleepThreshold;
                }
            }
        }
    }
}