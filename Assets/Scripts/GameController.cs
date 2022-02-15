using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().LoadSpellListData();
        GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase.Sort();


        PopulateSpellgems();
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
        }
    }


}
