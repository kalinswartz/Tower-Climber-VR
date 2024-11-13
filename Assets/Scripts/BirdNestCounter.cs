using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BirdNestCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nestCountText;
    private int totalNests;
    private int grabbedNests = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalNests = this.transform.childCount;

        UpdateUI();
    }

    private void UpdateUI()
    {
        nestCountText.text = $"Bird Nests Removed: {grabbedNests} / {totalNests}";
        if (grabbedNests == totalNests)
        {
            nestCountText.color = Color.green;
        } else
        {
            nestCountText.color = Color.red;
        }
    }

    public void onNestRelease()
    {
        grabbedNests++;
        UpdateUI();
    }
}
