using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    //List of the different camera view, and a variable to hold the current view
    public static List<Vector3> viewPositionList = new List<Vector3>();
    public static int currentView = 2;

    //List of all learned spellgems
    public static List<int> learnedSpellIDs = new List<int>();

    //Variables to assign the UI elements
    [SerializeField] TextMeshProUGUI goLeftButton;
    [SerializeField] TextMeshProUGUI goRightButton;
    [SerializeField] TextMeshProUGUI currentGod;

    //Counters for mastery
    [SerializeField] private int abjurationCount = 0;
    [SerializeField] private int IllusionCount = 0;
    [SerializeField] private int ConjurationCount = 0;
    [SerializeField] private int EnchantmentCount = 0;
    [SerializeField] private int EvocationCount = 0;
    [SerializeField] private int DivinationCount = 0;
    [SerializeField] private int NecromancyCount = 0;
    [SerializeField] private int TransmutationCount = 0;

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


}
