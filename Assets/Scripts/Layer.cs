using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField] private LayerScriptableObject layerSO;  // Reference to the ScriptableObject containing layer data
    [SerializeField] private DragController button;  // Reference to the button controller

    public bool isInRightOrder;  // Flag to indicate if the button is in the right order

    private GameObject importantItem;  // Reference to the important item GameObject
    private SpriteRenderer importantItemRenderer;  // Reference to the SpriteRenderer component of the important item

    private const int RightOrderSortingOrder = 1;  // Sorting order value when in the right order
    private const int WrongOrderSortingOrder = 0;  // Sorting order value when not in the right order

    private void Start()
    {
        // Find the important item GameObject in the scene
        importantItem = GameObject.Find(layerSO.importantItemName);

        // If the important item is found
        if (importantItem != null)
        {
            // Get the SpriteRenderer component of the important item
            importantItemRenderer = importantItem.GetComponent<SpriteRenderer>();

            // Check if the important item has a SpriteRenderer component
            if (importantItemRenderer == null)
            {
                Debug.LogError("Important item does not have a SpriteRenderer component.");
            }
        }
        else
        {
            // Log an error if the important item is not found
            Debug.LogError("Important item with name " + layerSO.importantItemName + " not found in the scene.");
        }
    }

    void Update()
    {
        // Check if button and layerSO are not null
        if (button != null && layerSO != null)
        {
            // Check if the button index matches the order index from the ScriptableObject
            isInRightOrder = button.index == layerSO.orderIndex;

            // Set the sorting order of the important item based on whether it's in the right order
            SetSortingOrderOfImportantItem(isInRightOrder);
        }
    }

    private void SetSortingOrderOfImportantItem(bool isInRightOrder)
    {
        // Check if the important item Renderer is not null
        if (importantItemRenderer != null)
        {
            // Set the sorting order of the important item based on whether it's in the right order
            importantItemRenderer.sortingOrder = isInRightOrder ? RightOrderSortingOrder : WrongOrderSortingOrder;
        }
    }
}
