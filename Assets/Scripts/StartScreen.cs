using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartScreen : MonoBehaviour
{
    [SerializeField] Canvas startScreen;
    [SerializeField] XRRayInteractor leftRay;
    [SerializeField] XRRayInteractor rightRay;
    [SerializeField] LocomotionSystem locomotionSystem;

    [SerializeField] Canvas infoPanel;
    [SerializeField] Canvas cameraUI;

    [SerializeField] GameObject tutorial;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.enabled = true;
        leftRay.gameObject.SetActive(true);
        rightRay.gameObject.SetActive(true);
        locomotionSystem.gameObject.SetActive(false);
        infoPanel.gameObject.SetActive(false);
        cameraUI.gameObject.SetActive(false);
        tutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButton()
    {
        startScreen.enabled = false;
        leftRay.gameObject.SetActive(false);
        rightRay.gameObject.SetActive(false);
        locomotionSystem.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(true);
        cameraUI.gameObject.SetActive(true);
    }

    public void tutorialButton()
    {
        startScreen.enabled = false;
        leftRay.gameObject.SetActive(false);
        rightRay.gameObject.SetActive(false);
        locomotionSystem.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(true);
        cameraUI.gameObject.SetActive(true);
        tutorial.SetActive(true);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
