using UnityEngine;
using UnityEngine.EventSystems;

// This class handles dragging behavior for UI elements vertically.
public class DragController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform currentTransform; // Reference to the RectTransform of the currently dragged object
    private GameObject mainContent; // Reference to the parent GameObject of the currently dragged object
    private Vector3 currentPossition; // Stores the initial position of the currently dragged object
    private int totalChild; // Stores the total number of child objects under the mainContent
    public int index; // Stores the index of the currently dragged object in relation to its siblings

    // Called when the script starts.
    private void Start()
    {
        // Initialize drag parameters and get the index of the currently dragged object.
        InitializeDragParameters();
        GetIndex();
    }

    // Called every frame.
    private void Update()
    {
        // Check if the transform of the currently dragged object has changed.
        // If it has, update the index of the currently dragged object.
        if (transform.hasChanged)
        {
            GetIndex();
        }
    }

    // Called when a pointer is pressed on the object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        // Reinitialize drag parameters when pointer is pressed.
        InitializeDragParameters();
    }

    // Called when a pointer is dragged on the object this script is attached to.
    public void OnDrag(PointerEventData eventData)
    {
        // Update the Y position of the currently dragged object based on the pointer's position.
        currentTransform.position =
            new Vector3(currentTransform.position.x, eventData.position.y, currentTransform.position.z);

        // Loop through each child object under the mainContent.
        for (int i = 0; i < totalChild; i++)
        {
            // Skip the currently dragged object.
            if (i != currentTransform.GetSiblingIndex())
            {
                // Get the Transform component of the current child object.
                Transform otherTransform = mainContent.transform.GetChild(i);

                // Calculate the distance between the currently dragged object and the other object.
                int distance = (int)Vector3.Distance(currentTransform.position, otherTransform.position);

                // If the distance is less than or equal to 10 units, swap positions.
                if (distance <= 10)
                {
                    Vector3 otherTransformOldPosition = otherTransform.position;
                    otherTransform.position = new Vector3(otherTransform.position.x, currentPossition.y,
                        otherTransform.position.z);
                    currentTransform.position = new Vector3(currentTransform.position.x, otherTransformOldPosition.y,
                        currentTransform.position.z);
                    currentTransform.SetSiblingIndex(otherTransform.GetSiblingIndex());
                    currentPossition = currentTransform.position;
                }
            }
        }
    }

    // Called when a pointer is released from the object this script is attached to.
    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset the position of the currently dragged object to its initial position.
        currentTransform.position = currentPossition;
    }

    // Function to initialize drag parameters.
    private void InitializeDragParameters()
    {
        currentPossition = currentTransform.position;
        mainContent = currentTransform.parent.gameObject;
        totalChild = mainContent.transform.childCount;
    }

    // Function to get the index of the currently dragged object among its siblings.
    private void GetIndex()
    {
        int count = 1;

        // Loop through each child object under the mainContent.
        foreach (Transform childTransform in mainContent.transform)
        {
            // If the currently iterated child transform is equal to the transform of the currently dragged object,
            // set its index.
            if (this.gameObject.transform == childTransform)
            {
                index = count;
                break; // Exit the loop once the index is found
            }
            else
            {
                count++;
            }
        }
    }
}
