using System.Collections;
using UnityEngine;

public class AmongUs : MonoBehaviour
{ 
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color selectedColor = Color.blue;
    [SerializeField] private Color correctColor = Color.green;
    public GameObject door;
    public GameObject engineInside;
    public GameObject winPopup; 
    public float displayDuration = 3f; 



    private GameObject firstSelection = null;
    private GameObject secondSelection = null;
    private int correctMatches = 0;
    private int totalMatches = 3;
    private int wrongCount = 0;

    private void Start()
    {
        if (winPopup != null)
        {
            winPopup.SetActive(false);
        }
    }

    public void SelectDrawing(GameObject drawing)
    {
        if (firstSelection == null)
        {
            firstSelection = drawing;
            SetDrawingColor(drawing, selectedColor);
        }
        else if (secondSelection == null && drawing != firstSelection)
        {
            secondSelection = drawing;
            SetDrawingColor(drawing, selectedColor);
            CheckMatch();
        }
    }

    private void CheckMatch()
    {
        bool isMatch = ValidateMatch(firstSelection, secondSelection);

        if (isMatch)
        {
            SetDrawingColor(firstSelection, correctColor);
            SetDrawingColor(secondSelection, correctColor);
            correctMatches++;
            CheckWinCondition();
        }
        else
        {
            SetDrawingColor(firstSelection, defaultColor);
            SetDrawingColor(secondSelection, defaultColor);
        }

        firstSelection = null;
        secondSelection = null;
    }



    private void SetDrawingColor(GameObject drawing, Color color)
    {
        Renderer renderer = drawing.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }


    
    private bool ValidateMatch(GameObject first, GameObject second)
    {
        return first.name == second.name;
    }

    private void CheckWinCondition()
    {
        if (correctMatches >= totalMatches)
        {
            if (winPopup != null)
            {
                winPopup.SetActive(true);
                door.SetActive(false);
                engineInside.SetActive(true);

                StartCoroutine(HidePopupAfterDelay());

            }
            Debug.Log("You Win!");
        }
    }
    
    IEnumerator HidePopupAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        winPopup.SetActive(false);
    }
   
}

