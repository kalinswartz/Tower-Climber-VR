using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SafetyHookManager : MonoBehaviour
{
    public GameObject safetyHook;
    public GameObject invisibleFloor; 
    public Transform player; 
    public float floorOffset = 0.5f; // Offset to place the invisible floor slightly below the player
    public InputActionReference safetyHookReference = null;
    private bool isActive = false; // Only allow hook placement when true

    public void Awake()
    {
        safetyHookReference.action.started += placeSafetyHook;
    }
    // Start is called before the first frame update
    public void OnDestroy()
    {
        safetyHookReference.action.started -= placeSafetyHook;
    }

    private void placeSafetyHook(InputAction.CallbackContext context)
    {
        if (!isActive) return; // Only allow hook placement if inside the trigger zone
        Debug.Log("Safety Hook placed");

        Vector3 hookPosition = new Vector3(player.position.x - 0.5f, player.position.y + 0.5f, player.position.z);
        safetyHook.transform.position = hookPosition;

        // Move invisible floor slightly below the player's position
        Vector3 floorPosition = new Vector3(player.position.x, player.position.y - floorOffset, player.position.z);
        invisibleFloor.transform.position = floorPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Activate safety hooks");
            isActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Deactivate safety hooks");
            isActive = false;
        }
    }
}
