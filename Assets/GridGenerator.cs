using System;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    #region Publics



    #endregion

    #region Unity API

    private void Awake()
    {
        _cellArray = new GameObject[_gridDimensions.x, _gridDimensions.y];
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid2D();
    }
    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        var mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(mousePosition);
        int x = Mathf.RoundToInt(mousePositionInWorldSpace.x);
        int y = Mathf.RoundToInt(mousePositionInWorldSpace.y);
        Vector2 roundedMousePositionInWorldSpace = new Vector2(x, y);
        if (x >= 0 && x < _gridDimensions.x && y >= 0  && y < _gridDimensions.y)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _cellArray[x, y].GetComponent<MeshRenderer>().material.color = Color.red;
                HighlightAvailableNearbyCells(x, y);
            }
            if (Input.GetMouseButtonDown(1))
            {
                _cellArray[x, y].GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }      
    }


    #endregion

    #region Main Methods

    private void GenerateGrid2D()
    {

        int gridCellCount = _gridDimensions.x * _gridDimensions.y;
        for (int i = 0; i < _gridDimensions.x; i++)
        {
            for (int j = 0; j < _gridDimensions.y; j++)
            {
                
                GameObject cellObject = Instantiate(m_gridCellPrefab, new Vector2(i, j), Quaternion.identity, transform);
                _cellArray[i, j] = cellObject;
                cellObject.name = $"Cell : {i}, {j}"; 
                float random = UnityEngine.Random.Range(0f, 1f);
                isObstacle = random <= 0.3f;
                if (isObstacle)
                {
                    _cellArray[i, j].GetComponent<MeshRenderer>().material.color = Color.black;
                    
                }
                else
                {
                    _cellArray[i, j].GetComponent<MeshRenderer>().material.color = Color.white;
                }        
            }
        }

    }

    private void HighlightAvailableNearbyCells(int x, int y)
    {
        //Check for the 4 cells nearby
        //           [x, y+1] 
        //  [x-1, y] [x, y  ] [x+1, y]
        //           [x, y-1] 
        Vector2 actualPosition = new Vector2(x, y);
        
            if (_cellArray[x - 1, y].GetComponent<MeshRenderer>().material.color == Color.white)
            {
                _cellArray[x - 1, y].GetComponent<MeshRenderer>().material.color = Color.blue;
            }

            if (_cellArray[x + 1, y].GetComponent<MeshRenderer>().material.color == Color.white)
            {
                _cellArray[x + 1, y].GetComponent<MeshRenderer>().material.color = Color.blue;
            }

            if (_cellArray[x, y - 1].GetComponent<MeshRenderer>().material.color == Color.white)
            {
                _cellArray[x, y - 1].GetComponent<MeshRenderer>().material.color = Color.blue;
            }

            if (_cellArray[x, y + 1].GetComponent<MeshRenderer>().material.color == Color.white)
            {
                _cellArray[x, y + 1].GetComponent<MeshRenderer>().material.color = Color.blue;
            }
         

           
    }

    private void HighlightAvailableNearbyCells()
    {
       
    }

    #endregion

    #region Utils



    #endregion

    #region Privates and Protected

    [SerializeField] private Vector2Int _gridDimensions;
    [SerializeField] private GameObject m_gridCellPrefab;
    private GameObject[,] _cellArray;
    bool isObstacle;
    bool isAvailable = false;

    #endregion

}
