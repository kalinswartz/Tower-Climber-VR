using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class WindGustManager : MonoBehaviour
{
    public ActionBasedController leftController;  // Left VR controller
    public ActionBasedController rightController; // Right VR controller
    public float minWindInterval = 5f;   // Minimum time between gusts
    public float maxWindInterval = 30f;  // Maximum time between gusts
    public float gustDuration = 5f;      // Duration of each gust
    public float maxVibrationIntensity = 1f;  // Maximum vibration intensity
    public AudioSource windAudioSource;  // AudioSource for wind sound

    private bool isGustActive = false;

    void Start()
    {
    
    }
    
    public void startWind()
    {
        StartCoroutine(WindGustRoutine());
    }
    private IEnumerator WindGustRoutine()
    {
        Debug.Log("Start windgust");
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWindInterval, maxWindInterval));
            StartCoroutine(TriggerWindGust());
        }
    }

    private IEnumerator TriggerWindGust()
    {
        Debug.Log("WINDGUST");
        isGustActive = true;
        float elapsed = 0f;

        windAudioSource.Play();

        while (elapsed < gustDuration)
        {
            elapsed += Time.deltaTime;
            float intensity = Mathf.Lerp(0.5f, maxVibrationIntensity, elapsed / gustDuration);

            // Vibrate both controllers with increasing intensity
            SendHapticFeedback(leftController, intensity);
            SendHapticFeedback(rightController, intensity);

            yield return null;
        }

        // Stop vibration after the gust ends
        SendHapticFeedback(leftController, 0);
        SendHapticFeedback(rightController, 0);

        isGustActive = false;
    }

    private void SendHapticFeedback(ActionBasedController controller, float intensity)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(intensity, 0.1f); // Sends vibration with intensity for 0.1s
        }
    }
}
