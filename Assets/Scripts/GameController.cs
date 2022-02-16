using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gamecontrollerInstance;

    // Start is called before the first frame update
    void Start()
    {
        //Loads the data from the spelllist and sorts it
        GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().LoadSpellListData();
        GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase.Sort();

        //Populates all active spellgems with data from spelllist
        PopulateSpellgems();
    }



    private void Awake()
    {

        //Checks to see if an instance already exists, and if so immediately deletes the new instance created.
        if (gamecontrollerInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        gamecontrollerInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method to find all spellgems by their id and populate their variables with corresponding data from the spelllist. Ends with setting the color of the sprite renderer by the school variable.
    public void PopulateSpellgems ()
    {
        List<GameObject> activeSpellgems = new List<GameObject>();
        activeSpellgems.AddRange(GameObject.FindGameObjectsWithTag("Spellgem"));

        for (int i = 0; i< activeSpellgems.Count; i++)
        {
            int tempID = activeSpellgems[i].GetComponent<SpellgemBehavior>().id;

            activeSpellgems[i].GetComponent<SpellgemBehavior>().level = GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase[tempID].level;
            activeSpellgems[i].GetComponent<SpellgemBehavior>().name = GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase[tempID].name;
            activeSpellgems[i].GetComponent<SpellgemBehavior>().school = GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase[tempID].school;
            activeSpellgems[i].GetComponent<SpellgemBehavior>().god = GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase[tempID].god;

            activeSpellgems[i].GetComponent<SpellgemBehavior>().SetSchoolColor();
            activeSpellgems[i].name = activeSpellgems[i].GetComponent<SpellgemBehavior>().name;
        }
    }

    


}
