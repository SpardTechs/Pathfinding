using TMPro;
using UnityEngine;

public class DisplayCoordinates : MonoBehaviour
{

    #region Publics



    #endregion

    #region Unity API

    private void Awake()
    {
        
        position = transform.position;
        coordText.text = " " + position.ToString("0"); 
    }
    private void Update()
    {
         
    }
    #endregion

    #region Main Methods


    #endregion

    #region Utils



    #endregion

    #region Privates and Protected

    [SerializeField] private TextMeshProUGUI coordText; 
    private Vector2 position;
    private GridGenerator _gridGenerator;
    

    #endregion

}