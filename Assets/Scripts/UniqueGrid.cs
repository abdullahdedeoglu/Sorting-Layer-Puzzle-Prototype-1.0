using UnityEngine;

public class UniqueGrid : MonoBehaviour
{

    private bool mouseOnSquare;

    private bool mouseDragging;

    public Sprite[] sprites;

    public SpriteRenderer spriteRenderer;

    [SerializeField] private int orderNumber;

    public BoxCollider2D boxCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
       spriteRenderer.sprite = sprites[0];
    }

    public void PaintGrid(bool isLeftClick, bool isDragging)
    {
        if(mouseOnSquare) // Change sprite of unique grid depend on which click is pressed
        {
            if (isLeftClick && isDragging)
            {
                spriteRenderer.sprite = sprites[1];
                ActivateBoxCollider();
            }

            if (!isLeftClick && isDragging)
            {
                if(spriteRenderer.sprite == sprites[1]) // For non painted grid's don't lose their collider
                    DeactivateBoxCollider();

                spriteRenderer.sprite = sprites[0];
            }
        }
    }

    public void ActivateBoxCollider()
    {
        boxCollider.isTrigger = false;
    }

    public void DeactivateBoxCollider()
    {
        boxCollider.isTrigger = true;
    }

    // Mouse Interaction Detections
    private void OnMouseOver()
    {
        mouseOnSquare = true;
    }

    private void OnMouseExit()
    {
        mouseOnSquare=false;
    }

    public void WriteOrderNumber(int orderIndex)
    {
        orderNumber = orderIndex;
    }

}
