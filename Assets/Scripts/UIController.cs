using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    //List of the different camera view, and a variable to hold the current view
    public static List<Vector3> viewPositionList = new List<Vector3>();
    public static int currentView = 2;

    //Variables to assign the UI elements
    [SerializeField] TextMeshProUGUI goLeftButton;
    [SerializeField] TextMeshProUGUI goRightButton;
    [SerializeField] TextMeshProUGUI currentGod;

    // Start is called before the first frame update
    void Start()
    {
        //We add the availible views to the list
        viewPositionList.Add(new Vector3(-40, 0, -10));
        viewPositionList.Add(new Vector3(-20, 0, -10));
        viewPositionList.Add(new Vector3(0, 0, -10));
        viewPositionList.Add(new Vector3(20, 0, -10));
        viewPositionList.Add(new Vector3(40, 0,-10));

        currentView = 2;
        

        //Changes the text on the left and right buttons to the names of the skill trees on the left and right
        ChangeUINames();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets the name of the side buttons, to show which view they will switch to
    public void ChangeUINames ()
    {
        if (currentView == 4)
        {
            goRightButton.text = "Euris";
            goLeftButton.text = "Tyreis";
            currentGod.text = "Silva & Morior";
        } else if (currentView == 3)
        {
            goRightButton.text = "Silva & Morior";
            goLeftButton.text = "Diatas";
            currentGod.text = "Tyreis";
        } else if (currentView == 2)
        {
            goRightButton.text = "Tyreis";
            goLeftButton.text = "Agon";
            currentGod.text = "Diatas";
        } else if (currentView == 1)
        {
            goRightButton.text = "Diatas";
            goLeftButton.text = "Euris";
            currentGod.text = "Agon";
        } else if (currentView == 0)
        {
            goRightButton.text = "Agon";
            goLeftButton.text = "Silva & Morior";
            currentGod.text = "Euris";
        }
    }


}
