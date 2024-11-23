using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbRepairManager : MonoBehaviour
{
    public bool isFixed = false;
    public int hitCount = 0;
    public ParticleSystem repairParticles;
    public AudioSource hitSound;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRController") && !isFixed)
        {
            hitCount++;
            Debug.Log(hitCount.ToString());

            if (hitSound != null)
            {
                hitSound.Play();
            }

            if (repairParticles != null)
            {
                repairParticles.Play();
            }

            // Check if the required number of hits has been reached
            if (hitCount >= 5)
            {
                isFixed = true;
                Debug.Log("LIGHT FIXED");
            }
        }
    }
}
