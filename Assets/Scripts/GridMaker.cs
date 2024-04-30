using UnityEngine;

public class GridMaker : MonoBehaviour
{
    [SerializeField] private GameObject gridPrefab;
    
    [SerializeField] private float size;

    [SerializeField] private float distance = 0.28f; //Pixel perfection fixes 

    private Vector3 startingPosition;

    private Sprite[] sprite;

    [SerializeField] private SceneScriptableObject sceneSO;

    private void Start()
    {
        startingPosition = transform.position;

        CreateGrid();
    }

    private void CreateGrid()
    {
        int orderCount = 0;
        for (int i = 0; i < size; i++) // Creating Grid With Starting From Top Left
        {
            for (int j = 0; j < size; j ++)
            {
                // Grid Creating
                GameObject grid = Instantiate(gridPrefab) as GameObject;

                grid.transform.position = new Vector3(startingPosition.x + i * distance, startingPosition.y - j * distance, 0);

                // Import The Scene View 
                UniqueGrid currentUniqueGrid;

                currentUniqueGrid = grid.GetComponent<UniqueGrid>();

                currentUniqueGrid.sprites[0] = sceneSO.sceneSprites[(j*32) + i]; //Grid and sprite order differences

                //Order Calculation Utilities (Will be deleted)
                currentUniqueGrid.WriteOrderNumber(orderCount);

                //If current grid's order in collider order list, activate collider

                bool hasCollider = sceneSO.collisionGridList.Contains(orderCount);

                if (hasCollider) currentUniqueGrid.ActivateBoxCollider();
               
                orderCount++;
            }
        }
    }

    #region VALIDATION FIELD

    //private void OnValidate()
    //{
    //    CreateGrid();
    //}

    #endregion VALIDATION FIELD
}
