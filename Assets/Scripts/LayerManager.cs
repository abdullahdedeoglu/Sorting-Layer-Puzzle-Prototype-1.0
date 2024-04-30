using TMPro;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField] private Layer[] layers;
    [SerializeField] private TextMeshProUGUI youPassedText;

    private bool everythingInItsRightPlace;

    private void Start()
    {
        youPassedText.enabled = false;
    }

    private void Update()
    {
        if (!everythingInItsRightPlace)  // Only check layers if everything is not in its right place
        {
            CheckLayers();
        }
    }

    private void CheckLayers()
    {
        // Assume everything is in its right place until proven otherwise
        everythingInItsRightPlace = true;

        foreach (Layer layer in layers)
        {
            if (!layer.isInRightOrder)
            {
                // If any layer is not in the right order, set the flag to false and exit the loop
                everythingInItsRightPlace = false;
                return;
            }
        }

        // If all layers are in the right order, enable the "You Passed" text
        youPassedText.enabled = true;
    }
}
