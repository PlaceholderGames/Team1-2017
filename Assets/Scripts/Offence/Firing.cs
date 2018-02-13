using UnityEngine;

namespace Assets.Scripts.Offence
{
    class Firing : MonoBehaviour
    {
        public GameObject projectile = null; //prefab of projectile
        private float countdown = 0f;

        void FixedUpdate()
        {
            countdown -= Time.deltaTime;

            ProbeObject probe = GetComponent<ProbeObject>();
            if (probe.Munitions > 0 && countdown <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Instantiate(projectile, new Vector3(probe.GetPosition().x, probe.GetPosition().y + 2.4f, probe.GetPosition().z + 4f), probe.GetRotation());
                }
                countdown = 0.5f;
            }
        }
    }
}