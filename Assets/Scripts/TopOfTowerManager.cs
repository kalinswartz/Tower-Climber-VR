using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TopOfTowerManager : MonoBehaviour
{
    [SerializeField] private SafetyHookManager safetyHookManager;
    [SerializeField] public GameObject topSafetyNet;
    [SerializeField] public GameObject topSafetyHook;
    [SerializeField] public GameObject topCanvas;

    [SerializeField] public GameObject endScreen;
    [SerializeField] XRRayInteractor leftRay;
    [SerializeField] XRRayInteractor rightRay;

    [SerializeField] public LightBulbRepairManager lightBulbRepairManager;
    [SerializeField] public GameObject lightBulb_light;
    [SerializeField] public GameObject lightBulb;
    [SerializeField] public Material light_on;
    [SerializeField] public Material light_off;
    [SerializeField] public AudioSource button_click;
    Renderer light_renderer;

    // Start is called before the first frame update
    void Start()
    {
        topSafetyNet.SetActive(false);
        topSafetyHook.SetActive(false);
        topCanvas.SetActive(false);
        endScreen.SetActive(false);
        light_renderer = lightBulb.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("At the top");
            safetyHookManager.invisibleFloor.SetActive(false);
            safetyHookManager.safetyHookReference.action.started -= safetyHookManager.placeSafetyHook;
            topSafetyNet.SetActive(true);
            topSafetyHook.SetActive(true);
            topCanvas.SetActive(true);

        }
    }

    public void buttonPress()
    {
        Debug.Log("Button pressed");
        if (lightBulbRepairManager.isFixed)
        {
            button_click.Play();
            if (lightBulb_light.gameObject.activeSelf)
            {
                lightBulb_light.SetActive(false);
                light_renderer.material = light_off;
            } else
            {
                lightBulb_light.SetActive(true);
                light_renderer.material = light_on;
            }
            endScreen.gameObject.SetActive(true);
            leftRay.gameObject.SetActive(true);
            rightRay.gameObject.SetActive(true);
            topCanvas.gameObject.SetActive(false);

        }
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
