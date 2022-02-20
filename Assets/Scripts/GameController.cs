using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gamecontrollerInstance;
    public GameObject database;
    public GameObject spellgemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the database LoadCVS script and sets the database variable.
        database = GameObject.Find("SpellDatabase");

        //Loads the data from the spelllist and sorts it
        database.GetComponent<LoadCSV>().LoadSpellListData();
        database.GetComponent<LoadCSV>().spellgemDatabase.Sort();


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

    public void SpawnGems ()
    {
        for (int i = 0; i < database.GetComponent<LoadCSV>().spellgemDatabase.Count; i++)
        {
            GameObject tempSpellgem;
            int levelOffset;

            //Sets an offset to the spawn position x based on the level of the gem
            switch (database.GetComponent<LoadCSV>().spellgemDatabase[i].level)
            {
                case 0:
                    levelOffset = -6;
                    break;
                case 1:
                    levelOffset = -2;
                    break;
                case 2:
                    levelOffset = 2;
                    break;
                case 3:
                    levelOffset = 6;
                    break;
                default:
                    levelOffset = 0;
                    break;
            }

            //Checks the god variable and spawns the gem on the corresponding tree, offset by level. If all gods have the gem, spawns a gem for each
            switch (database.GetComponent<LoadCSV>().spellgemDatabase[i].god)
            {
                case "Diatas":
                tempSpellgem = Instantiate(spellgemPrefab, new Vector3(0 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("DiatasTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;
                    break;
                case "Euris":
                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(-40 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("EurisTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;
                    break;
                case "Tyreis":
                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(20 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("TyreisTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;
                    break;
                case "Agon":
                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(-20 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("AgonTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;
                    break;
                case "Silva & Morior":
                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(40 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("SilvaMoriorTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;
                    break;
                case "All":
                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(40 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("SilvaMoriorTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;

                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(-20 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("AgonTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;

                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(20 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("TyreisTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;

                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(-40 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("EurisTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;

                    tempSpellgem = Instantiate(spellgemPrefab, new Vector3(0 + levelOffset, 0, -1), transform.rotation);
                    tempSpellgem.transform.parent = GameObject.Find("DiatasTree").transform;
                    tempSpellgem.GetComponent<SpellgemBehavior>().id = database.GetComponent<LoadCSV>().spellgemDatabase[i].id;

                    break;
                default:
                    Debug.Log("No God found for spellgem");
                    break;
            }
            
        }
    }

    


}
