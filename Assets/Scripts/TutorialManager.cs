using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
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
        light_renderer = lightBulb.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tutorial_buttonPress()
    {
        Debug.Log("tut Button pressed");
        if (lightBulbRepairManager.isFixed)
        {
            button_click.Play();
            if (lightBulb_light.gameObject.activeSelf)
            {
                lightBulb_light.SetActive(false);
                light_renderer.material = light_off;
            }
            else
            {
                lightBulb_light.SetActive(true);
                light_renderer.material = light_on;
            }

        }
    }
}
