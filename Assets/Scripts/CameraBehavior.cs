using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] GameObject uIController;

    // Start is called before the first frame update
    void Start()
    {
        MoveToView(2);
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToView (int view)
    {
        gameObject.transform.position = UIController.viewPositionList[view];
        uIController.GetComponent<UIController>().ChangeUINames();


    }

    public void MoveViewLeft ()
    {
        if (UIController.currentView > 0)
        {
            gameObject.transform.position = UIController.viewPositionList[UIController.currentView-1];
            UIController.currentView = UIController.currentView - 1;
            uIController.GetComponent<UIController>().ChangeUINames();
        } else
        {
            gameObject.transform.position = UIController.viewPositionList[4];
            UIController.currentView = 4;
            uIController.GetComponent<UIController>().ChangeUINames();
        }
    }

    public void MoveViewRight()
    {
        if (UIController.currentView < 4)
        {
            gameObject.transform.position = UIController.viewPositionList[UIController.currentView + 1];
            UIController.currentView = UIController.currentView + 1;
            uIController.GetComponent<UIController>().ChangeUINames();
        } else
        {
            gameObject.transform.position = UIController.viewPositionList[0];
            UIController.currentView = 0;
            uIController.GetComponent<UIController>().ChangeUINames();
        }
    }

}
