using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //List of the different camera view, and a variable to hold the current view
    public static List<Vector3> viewPositionList = new List<Vector3>();
    public static int currentView = 2;

    

    //variables for statistics
    private int totalSpells;
    public static int lvl0SpellsLearned;
    public static int lvl1SpellsLearned;
    public static int lvl2SpellsLearned;
    public static int lvl3SpellsLearned;

    int spellslot1;
    int spellslot2;
    int spellslot3;
    int spellslot4;
    int spellslot5;
    int spellslot6;
    int spellslot7;

    [SerializeField] TextMeshProUGUI spellslot1Text;
    [SerializeField] TextMeshProUGUI spellslot2Text;
    [SerializeField] TextMeshProUGUI spellslot3Text;
    [SerializeField] TextMeshProUGUI spellslot4Text;
    [SerializeField] TextMeshProUGUI spellslot5Text;
    [SerializeField] TextMeshProUGUI spellslot6Text;
    [SerializeField] TextMeshProUGUI spellslot7Text;



    //Spellbook variables
    public static bool spellbookOn = false;
    [SerializeField] GameObject statBlockObject;
    [SerializeField] GameObject spellBookObject;
    [SerializeField] TextMeshProUGUI spellbookButtonText;

    [SerializeField] Button spellbookButton;
    [SerializeField] Sprite buttonPressedImage;
    [SerializeField] Sprite buttonImage;

    [SerializeField] GameObject lvl0Column;
    [SerializeField] GameObject lvl1Column;
    [SerializeField] GameObject lvl2Column;
    [SerializeField] GameObject lvl3Column;

    [SerializeField] GameObject spellDatabaseObject;
    [SerializeField] GameObject inventorySpellPrefab;

    //Variables to assign the UI elements
    [SerializeField] TextMeshProUGUI goLeftButton;
    [SerializeField] TextMeshProUGUI goRightButton;
    [SerializeField] TextMeshProUGUI currentGod;

    //Counters for mastery
 private int abjurationCount = 0;
 private int IllusionCount = 0;
 private int ConjurationCount = 0;
 private int EnchantmentCount = 0;
 private int EvocationCount = 0;
 private int DivinationCount = 0;
 private int NecromancyCount = 0;
 private int TransmutationCount = 0;

    [SerializeField] private TextMeshProUGUI abjurationCountText;
    [SerializeField] private TextMeshProUGUI IllusionCountText;
    [SerializeField] private TextMeshProUGUI ConjurationCountText;
    [SerializeField] private TextMeshProUGUI EnchantmentCountText;
    [SerializeField] private TextMeshProUGUI EvocationCountText;
    [SerializeField] private TextMeshProUGUI DivinationCountText;
    [SerializeField] private TextMeshProUGUI NecromancyCountText;
    [SerializeField] private TextMeshProUGUI TransmutationCountText;

    [SerializeField] private TextMeshProUGUI abjurationMasteryText;
    [SerializeField] private TextMeshProUGUI IllusionMasteryText;
    [SerializeField] private TextMeshProUGUI ConjurationMasteryText;
    [SerializeField] private TextMeshProUGUI EnchantmentMasteryText;
    [SerializeField] private TextMeshProUGUI EvocationMasteryText;
    [SerializeField] private TextMeshProUGUI DivinationMasteryText;
    [SerializeField] private TextMeshProUGUI NecromancyMasteryText;
    [SerializeField] private TextMeshProUGUI TransmutationMasteryText;


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

    public void AddToMasteryCount(string school)
    {
        switch (school)
        {
            case "Abjuration":
                abjurationCount += 1;
                abjurationCountText.text = abjurationCount.ToString();
                abjurationMasteryText.text = CheckMastery(abjurationCount);
                break;
            case "Illusion":
                IllusionCount += 1;
                IllusionCountText.text = IllusionCount.ToString();
                IllusionMasteryText.text = CheckMastery(IllusionCount);
                break;
            case "Conjuration":
                ConjurationCount += 1;
                ConjurationCountText.text = ConjurationCount.ToString();
                ConjurationMasteryText.text = CheckMastery(ConjurationCount);
                break;
            case "Enchantment":
                EnchantmentCount += 1;
                EnchantmentCountText.text = EnchantmentCount.ToString();
                EnchantmentMasteryText.text = CheckMastery(EnchantmentCount);
                break;
            case "Evocation":
                EvocationCount += 1;
                EvocationCountText.text = EvocationCount.ToString();
                EvocationMasteryText.text = CheckMastery(EvocationCount);
                break;
            case "Divination":
                DivinationCount += 1;
                DivinationCountText.text = DivinationCount.ToString();
                DivinationMasteryText.text = CheckMastery(DivinationCount);

                break;
            case "Necromancy":
                NecromancyCount += 1;
                NecromancyCountText.text = NecromancyCount.ToString();
                NecromancyMasteryText.text = CheckMastery(NecromancyCount);
                break;
            case "Transmutation":
                TransmutationCount += 1;
                TransmutationCountText.text = TransmutationCount.ToString();
                TransmutationMasteryText.text = CheckMastery(TransmutationCount);
                break;
            default:
                Debug.Log("No count added");
                break;
        }
    }

    public void RemoveFromMasteryCount(string school)
    {
        switch (school)
        {
            case "Abjuration":
                abjurationCount -= 1;
                abjurationCountText.text = abjurationCount.ToString();
                abjurationMasteryText.text = CheckMastery(abjurationCount);
                break;
            case "Illusion":
                IllusionCount -= 1;
                IllusionCountText.text = IllusionCount.ToString();
                IllusionMasteryText.text = CheckMastery(IllusionCount);
                break;
            case "Conjuration":
                ConjurationCount -= 1;
                ConjurationCountText.text = ConjurationCount.ToString();
                ConjurationMasteryText.text = CheckMastery(ConjurationCount);
                break;
            case "Enchantment":
                EnchantmentCount -= 1;
                EnchantmentCountText.text = EnchantmentCount.ToString();
                EnchantmentMasteryText.text = CheckMastery(EnchantmentCount);
                break;
            case "Evocation":
                EvocationCount -= 1;
                EvocationCountText.text = EvocationCount.ToString();
                EvocationMasteryText.text = CheckMastery(EvocationCount);
                break;
            case "Divination":
                DivinationCount -= 1;
                DivinationCountText.text = DivinationCount.ToString();
                DivinationMasteryText.text = CheckMastery(DivinationCount);

                break;
            case "Necromancy":
                NecromancyCount -= 1;
                NecromancyCountText.text = NecromancyCount.ToString();
                NecromancyMasteryText.text = CheckMastery(NecromancyCount);
                break;
            case "Transmutation":
                TransmutationCount -= 1;
                TransmutationCountText.text = TransmutationCount.ToString();
                TransmutationMasteryText.text = CheckMastery(TransmutationCount);
                break;
            default:
                Debug.Log("No count added");
                break;
        }
    }

    public string CheckMastery ( int schoolCount)
    {
        
        if (schoolCount >= 12)
        {
            return "Master";
        } else if (schoolCount >= 9)
        {
            return "Journeyman";
        } else if (schoolCount >= 6)
        {
            return "Apprentice";
        } else if (schoolCount >= 3)
        {
            return "Novice";
        } else
        {
            return "Amateur";
        }
    }

    public void UpdateStats ()
    {


        spellslot1 = (lvl0SpellsLearned / 4) + (lvl1SpellsLearned / 3) + (lvl2SpellsLearned/2) + (lvl3SpellsLearned);
        spellslot2 = (lvl0SpellsLearned / 5) + (lvl1SpellsLearned / 4) + (lvl2SpellsLearned/3) + (lvl3SpellsLearned/2);
        spellslot3 = (lvl0SpellsLearned / 6) + (lvl1SpellsLearned / 5) + (lvl2SpellsLearned/4) + (lvl3SpellsLearned/3);

        ConvertAllSpellslots();

        if(lvl1SpellsLearned>0 && spellslot1==0 && spellslot2==0 && spellslot3==0) { spellslot1 = 1; }
        if (lvl2SpellsLearned>0 && spellslot2 == 0 && spellslot3 == 0) { spellslot2 = 1; }
        if (lvl3SpellsLearned > 0 && spellslot3 == 0) { spellslot3 = 1; }



        spellslot1Text.text = "" + spellslot1;
        spellslot2Text.text = "" + spellslot2;
        spellslot3Text.text = "" + spellslot3;
        spellslot4Text.text = "" + spellslot4;
        spellslot5Text.text = "" + spellslot5;
        spellslot6Text.text = "" + spellslot6;
        spellslot7Text.text = "" + spellslot7;


    }

    public void ConvertSpellslot1 ()
    {
        while (spellslot1 > 5)
        {
            spellslot1 -= 2;
            spellslot2 += 1;
        }
    }

    public void ConvertSpellslot2()
    {
        while (spellslot2 > 5)
        {
            spellslot2 -= 2;
            spellslot3 += 1;
        }
    }

    public void ConvertSpellslot3()
    {
        while (spellslot3 > 5)
        {
            spellslot3 -= 2;
            spellslot4 += 1;
        }
    }

    public void ConvertSpellslot4()
    {
        while (spellslot4 > 5)
        {
            spellslot4 -= 2;
            spellslot5 += 1;
        }
    }

    public void ConvertSpellslot5()
    {
        while (spellslot5 > 5)
        {
            spellslot5 -= 2;
            spellslot6 += 1;
        }
    }
    public void ConvertSpellslot6()
    {
        while (spellslot6 > 5)
        {
            spellslot6 -= 2;
            spellslot7 += 1;
        }
    }

    public void ConvertAllSpellslots ()
    {
        ConvertSpellslot1();
        ConvertSpellslot2();
        ConvertSpellslot3();
        ConvertSpellslot4();
        ConvertSpellslot5();
        ConvertSpellslot6();
    }

    public void ToggleSpellbook ()
    {
        if (!spellbookOn)
        {
            spellbookOn = true;
            spellbookButton.image.sprite = buttonPressedImage;
            statBlockObject.SetActive(false);
            spellBookObject.SetActive(true);
            spellbookButtonText.transform.Translate(Vector2.down * 12);

            UpdateSpellbook();

        } else
        {
            spellbookOn = false;
            spellbookButton.image.sprite = buttonImage;
            statBlockObject.SetActive(true);
            spellBookObject.SetActive(false);
            spellbookButtonText.transform.Translate(Vector2.up * 12);

        }
    }

    public void UpdateSpellbook ()
    {
        //Clear the spellbook
        int childs0 = lvl0Column.transform.childCount;
        if (childs0 != 0)
        {
            for (int i = childs0 - 1; i >= 0; i--)
            {
                GameObject.Destroy(lvl0Column.transform.GetChild(i).gameObject);
            }
        }
        
        int childs1 = lvl1Column.transform.childCount;
        if (childs1 != 0)
        {
            for (int i = childs1 - 1; i >= 0; i--)
            {
                GameObject.Destroy(lvl1Column.transform.GetChild(i).gameObject);
            }
        }

        int childs2 = lvl2Column.transform.childCount;
        if (childs2 != 0)
        {
            for (int i = childs2 - 1; i >= 0; i--)
            {
                GameObject.Destroy(lvl2Column.transform.GetChild(i).gameObject);
            }
        }

        int childs3 = lvl3Column.transform.childCount;
        if (childs3 != 0)
        {
            for (int i = childs3 - 1; i >= 0; i--)
            {
                GameObject.Destroy(lvl3Column.transform.GetChild(i).gameObject);
            }
        }

        //For each spell in the learned ID list, check their level and create a text object in the corresponding column
        for (int i = 0; i < GameController.gamecontrollerInstance.learnedSpellIDList.Count; i++)
        {
            

            if (spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].level == 0)
            {
                GameObject currentSpell;
                currentSpell = Instantiate(inventorySpellPrefab, lvl0Column.transform);
                currentSpell.GetComponentInChildren<TextMeshProUGUI>().text = spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].name;

            } else if (spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].level == 1)
            {
                GameObject currentSpell;
                currentSpell = Instantiate(inventorySpellPrefab, lvl1Column.transform);
                currentSpell.GetComponentInChildren<TextMeshProUGUI>().text = spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].name;
            }
            else if (spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].level == 2)
            {
                GameObject currentSpell;
                currentSpell = Instantiate(inventorySpellPrefab, lvl2Column.transform);
                currentSpell.GetComponentInChildren<TextMeshProUGUI>().text = spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].name;
            }
            else if (spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].level == 3)
            {
                GameObject currentSpell;
                currentSpell = Instantiate(inventorySpellPrefab, lvl3Column.transform);
                currentSpell.GetComponentInChildren<TextMeshProUGUI>().text = spellDatabaseObject.GetComponent<LoadCSV>().spellgemDatabase[GameController.gamecontrollerInstance.learnedSpellIDList[i]].name;
            }
            
        }
    }

    public void ResetStatCounters ()
    {
        lvl0SpellsLearned = 0;
        lvl1SpellsLearned = 0;
        lvl2SpellsLearned = 0;
        lvl3SpellsLearned = 0;

        spellslot1 = 0;
        spellslot2 = 0;
        spellslot3 = 0;
        spellslot4 = 0;
        spellslot5 = 0;
        spellslot6 = 0;
        spellslot7 = 0;

        spellslot1Text.text = ""+spellslot1;
        spellslot2Text.text = "" + spellslot2;
        spellslot3Text.text = "" + spellslot3;
        spellslot4Text.text = "" + spellslot4;
        spellslot5Text.text = "" + spellslot5;
        spellslot6Text.text = "" + spellslot6;
        spellslot7Text.text = "" + spellslot7;

        abjurationCount = 0;
        IllusionCount = 0;
        ConjurationCount = 0;
        EnchantmentCount = 0;
        EvocationCount = 0;
        DivinationCount = 0;
        NecromancyCount = 0;
        TransmutationCount = 0;

abjurationCountText.text = "" + 0;
IllusionCountText.text = "" + 0;
ConjurationCountText.text = "" + 0;
 EnchantmentCountText.text = "" + 0;
 EvocationCountText.text = "" + 0;
         DivinationCountText.text = "" + 0;
    NecromancyCountText.text = "" + 0;
         TransmutationCountText.text = "" + 0;

    abjurationMasteryText.text = "Amateur";
 IllusionMasteryText.text = "Amateur";
   ConjurationMasteryText.text = "Amateur";
 EnchantmentMasteryText.text = "Amateur";
        EvocationMasteryText.text = "Amateur";
        DivinationMasteryText.text = "Amateur";
       NecromancyMasteryText.text = "Amateur";
       TransmutationMasteryText.text = "Amateur";
    }




}
