using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SafetyHookManager : MonoBehaviour
{
    public GameObject safetyHook;
    public GameObject invisibleFloor; 
    public Transform player; 
    public float floorOffset = 0.5f; // Offset to place the invisible floor slightly below the player
    public Transform safetyHookPointsParent; // Parent object containing all predefined hook points
    public InputActionReference safetyHookReference = null;
    private bool isActive = false; // Only allow hook placement when true
    public WindGustManager windGustManager;

    public int numSafetyHooksPlaced = 0;
    [SerializeField] TextMeshProUGUI hookCountText; 

    public void Awake()
    {
        safetyHookReference.action.started += placeSafetyHook;
    }
    // Start is called before the first frame update
    public void OnDestroy()
    {
        safetyHookReference.action.started -= placeSafetyHook;
    }

    public void placeSafetyHook(InputAction.CallbackContext context)
    {
        if (!isActive) return; // Only allow hook placement if inside the trigger zone
        Debug.Log("Safety Hook placed");
        numSafetyHooksPlaced++;
        hookCountText.text = $"Safety Hooks Placed: {numSafetyHooksPlaced}";

        //Vector3 hookPosition = new Vector3(player.position.x - 0.5f, player.position.y + 0.5f, player.position.z);
        //safetyHook.transform.position = hookPosition;
        //Vector3 floorPosition = new Vector3(player.position.x, player.position.y - floorOffset, player.position.z);
        //invisibleFloor.transform.position = floorPosition;

        Transform nearestHookPoint = GetNearestHookPoint();
        if (nearestHookPoint != null)
        {
            Vector3 hookPosition = new Vector3(-0.3160807192325592f, nearestHookPoint.position.y, -8.923569679260254f);
            safetyHook.transform.position = hookPosition;

            // Move invisible floor slightly below the player's position
            Vector3 floorPosition = new Vector3(
                player.position.x,
                player.position.y - floorOffset,
                player.position.z
            );
            invisibleFloor.transform.position = floorPosition;
        }
    }

    private Transform GetNearestHookPoint()
    {
        Transform nearestPoint = null;
        float nearestDistance = float.MaxValue;

        foreach (Transform hookPoint in safetyHookPointsParent)
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1.0f, player.position.z);
            float distance = Vector3.Distance(playerPos, hookPoint.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPoint = hookPoint;
            }
        }

        return nearestPoint;
    }

    bool windStarted = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Activate safety hooks");
            isActive = true;
            if (windStarted == false)
            {
                windStarted = true;
                windGustManager.gameObject.SetActive(true);
                windGustManager.startWind();
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Deactivate safety hooks");
            isActive = false;
            windGustManager.gameObject.SetActive(false);
        }
    }
}
