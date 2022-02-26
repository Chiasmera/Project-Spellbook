using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public static GameController gamecontrollerInstance;
    public GameObject database;
    public GameObject spellgemPrefab;
    public List<int> learnedSpellIDList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaithWhileLoading());

        //Finds the database LoadCVS script and sets the database variable.
        database = GameObject.Find("SpellDatabase");

        //Loads the data from the spelllist and sorts it
        database.GetComponent<LoadCSV>().LoadSpellListData();
        database.GetComponent<LoadCSV>().spellgemDatabase.Sort();


        //Populates all active spellgems with data from spelllist
        PopulateSpellgems();
    }

    IEnumerator WaithWhileLoading ()
    {
        yield return new WaitForSecondsRealtime(5);

        GameObject.Find("LoadingScreen").SetActive(false);
    }

    //Class and methods for saving data in json
    [System.Serializable]
    class SaveData
    {
        public List<int> learnedSpellIDs;
    }

    public void SaveSpellIDs ()
    {
        SaveData data = new SaveData();
        data.learnedSpellIDs = learnedSpellIDList;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("List saved at"+Application.persistentDataPath);
    }



    public void LoadSpellIDs ()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            learnedSpellIDList = data.learnedSpellIDs;

            SetSavedSpellsLearned();
        } else
        {
            Debug.Log("Save file not found");
        }
    }

    public void SetSavedSpellsLearned ()
    {
        GameObject[] allSpells = GameObject.FindGameObjectsWithTag("Spellgem");

        List<GameObject> foundLearned = new List<GameObject>();

        for (int i = 0; i < allSpells.Length; i++)
        {
            GameObject currentSpellgem = allSpells[i];
            currentSpellgem.GetComponent<SpellgemBehavior>().isLearned = false;
            currentSpellgem.GetComponent<SpellgemBehavior>().learnedToken.SetActive(false);
            

            int currentID = currentSpellgem.GetComponent<SpellgemBehavior>().id;

            
            if (learnedSpellIDList.Contains(currentID))
            {

                foundLearned.Add(allSpells[i]);

            }

        }
        GameObject.Find("UI Controller").GetComponent<UIController>().ResetStatCounters();

        for (int i = 0; i < foundLearned.Count; i++) {
            if (!foundLearned[i].GetComponent<SpellgemBehavior>().isLearned)
            {
                foundLearned[i].GetComponent<SpellgemBehavior>().requirementMet = true;
                foundLearned[i].GetComponent<SpellgemBehavior>().SetLearned(true);
            }

        }

        GameObject.Find("UI Controller").GetComponent<UIController>().UpdateStats();

        if (UIController.spellbookOn == true)
        {
            GameObject.Find("UI Controller").GetComponent<UIController>().UpdateSpellbook();
        }
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
            activeSpellgems[i].GetComponent<SpellgemBehavior>().spellgemName = GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase[tempID].name;
            activeSpellgems[i].GetComponent<SpellgemBehavior>().school = GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase[tempID].school;
            activeSpellgems[i].GetComponent<SpellgemBehavior>().god = GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase[tempID].god;

            activeSpellgems[i].GetComponent<SpellgemBehavior>().SetSchoolColor();
            activeSpellgems[i].name = activeSpellgems[i].GetComponent<SpellgemBehavior>().spellgemName;
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
