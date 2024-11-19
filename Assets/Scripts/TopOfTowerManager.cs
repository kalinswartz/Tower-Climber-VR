using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopOfTowerManager : MonoBehaviour
{
    [SerializeField] private SafetyHookManager safetyHookManager;
    [SerializeField] public GameObject topSafetyNet;
    [SerializeField] public GameObject topSafetyHook;
    [SerializeField] public GameObject topCanvas;
    // Start is called before the first frame update
    void Start()
    {
        topSafetyNet.SetActive(false);
        topSafetyHook.SetActive(false);
        topCanvas.SetActive(false);
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
    }
}
