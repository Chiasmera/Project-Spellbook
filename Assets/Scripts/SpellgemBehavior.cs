using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellgemBehavior : MonoBehaviour
{

    //Fields
    public int id;
    public int level;
    public string spellgemName;
    public string school;
    public string god;
    public bool isLearned;
    public bool requirementMet;

    [SerializeField] private Sprite abjurationSprite;
    [SerializeField] private Sprite IllusionSprite;
    [SerializeField] private Sprite ConjurationSprite;
    [SerializeField] private Sprite EnchantmentSrite;
    [SerializeField] private Sprite EvocationSprite;
    [SerializeField] private Sprite DivinationSprite;
    [SerializeField] private Sprite NecromancySprite;
    [SerializeField] private Sprite TransmutationSprite;

    [SerializeField] private GameObject learnedTokenPrefab;
    [SerializeField] public GameObject learnedToken;

    //MouseOver variables
    [SerializeField] private  GameObject mouseOverBox;
    [SerializeField] private  TextMeshProUGUI mouseOverSpellnameText;
    [SerializeField] private  TextMeshProUGUI mouseOverLevelText;
    [SerializeField] private  TextMeshProUGUI mouseOverSchoolText;




    //Constructor
    public SpellgemBehavior(int id, int level, string name, string school, string god)
    {
        this.id = id;
        this.level = level;
        this.spellgemName = name;
        this.school = school;
        this.god = god;
    }

    private void Start()
    {
        mouseOverBox = GameObject.Find("MouseoverInfobox");
        mouseOverSpellnameText = GameObject.Find("MouseoverTitle").GetComponent<TextMeshProUGUI>();
        mouseOverLevelText = GameObject.Find("MouseoverLevelValue").GetComponent<TextMeshProUGUI>();
        mouseOverSchoolText = GameObject.Find("MouseoverSchoolValue").GetComponent<TextMeshProUGUI>();

        mouseOverBox.transform.position = new Vector3(2000, 2000, 0);
    }


    void Awake()
    {
        SpawnLearnedToken();




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ToggleLearned();
    }

    private void OnMouseOver()
    {
        EnableMouseover();

    }

    private void OnMouseExit()
    {
        DisableMouseover();
    }




    //Other Methods
    public void SetSchoolColor()
    {
        switch (school)
        {
            case "Abjuration":
                this.GetComponent<SpriteRenderer>().sprite = abjurationSprite;
                break;
            case "Illusion":
                this.GetComponent<SpriteRenderer>().sprite = IllusionSprite;
                break;
            case "Conjuration":
                this.GetComponent<SpriteRenderer>().sprite = ConjurationSprite;
                break;
            case "Enchantment":
                this.GetComponent<SpriteRenderer>().sprite = EnchantmentSrite;
                break;
            case "Evocation":
                this.GetComponent<SpriteRenderer>().sprite = EvocationSprite;
                break;
            case "Divination":
                this.GetComponent<SpriteRenderer>().sprite = DivinationSprite;

                break;
            case "Necromancy":
                this.GetComponent<SpriteRenderer>().sprite = NecromancySprite;
                this.GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,0.5f, 1f);
                break;
            case "Transmutation":
                this.GetComponent<SpriteRenderer>().sprite = TransmutationSprite;
                break;
            default:
                print("No school");
                break;
        }
    }

    public void SetLearned(bool state)
    {
        isLearned = state;
        learnedToken.SetActive(state);

        if (state)
        {
            if (!GameController.gamecontrollerInstance.learnedSpellIDList.Contains(this.id))
            {
                GameController.gamecontrollerInstance.learnedSpellIDList.Add(this.id);
            }

            if (level ==0)
            {
                UIController.lvl0SpellsLearned += 1;
            } else if (level == 1)
            {
                UIController.lvl1SpellsLearned += 1;
            }
            else if (level == 2)
            {
                UIController.lvl2SpellsLearned += 1;
            } else
            {
                UIController.lvl3SpellsLearned += 1;
            }


            GameObject.Find("UI Controller").GetComponent<UIController>().AddToMasteryCount(this.school);
            GameObject.Find("UI Controller").GetComponent<UIController>().UpdateStats();
            if ( UIController.spellbookOn == true)
            {
                GameObject.Find("UI Controller").GetComponent<UIController>().UpdateSpellbook();
            }

            


        } else
        {
            GameController.gamecontrollerInstance.learnedSpellIDList.Remove(this.id);

            if (level == 0)
            {
                UIController.lvl0SpellsLearned -= 1;
            }
            else if (level == 1)
            {
                UIController.lvl1SpellsLearned -= 1;
            }
            else if (level == 2)
            {
                UIController.lvl2SpellsLearned -= 1;
            }
            else
            {
                UIController.lvl3SpellsLearned -= 1;
            }

            GameObject.Find("UI Controller").GetComponent<UIController>().RemoveFromMasteryCount(this.school);
            GameObject.Find("UI Controller").GetComponent<UIController>().UpdateStats();

            if (UIController.spellbookOn == true)
            {
                GameObject.Find("UI Controller").GetComponent<UIController>().UpdateSpellbook();
            }

        }

        SetOthersOFSameID(this.id, state);

    }

    public void ToggleLearned()
    {
        if (isLearned == false && requirementMet == true)
        {
            SetLearned(true);

            
        }
        else if (isLearned == true )
        {
            SetLearned(false);

        }
    }

    public bool GetLearned()
    {
        return isLearned;
    }

    public void SpawnLearnedToken()
    {
        learnedToken = Instantiate(learnedTokenPrefab, gameObject.transform.position, gameObject.transform.rotation);
        learnedToken.transform.Rotate(new Vector3(0, 0, 1 * Random.Range(0, 180)));
        learnedToken.SetActive(false);
    }


    public void SetOthersOFSameID (int learnedID, bool state)
    {

            foreach (GameObject spellgem in GameObject.FindGameObjectsWithTag("Spellgem"))
            {
                if (spellgem.GetComponent<SpellgemBehavior>().id == learnedID)
                {
                spellgem.GetComponent<SpellgemBehavior>().isLearned = state;
                spellgem.GetComponent<SpellgemBehavior>().learnedToken.SetActive(state);
            }
            }


    }

    public void EnableMouseover( )
    {
        
        mouseOverBox.SetActive(true);
        float mousePosX;
        float mousePosY;

        if (Input.mousePosition.x < 160)
        {
            mousePosX = Input.mousePosition.x + 80;
        } else {
            mousePosX = Input.mousePosition.x - 80;
        }

        if (Input.mousePosition.y > 400)
        {
            mousePosY = Input.mousePosition.y -60 ;
        }
        else
        {
            mousePosY = Input.mousePosition.y +60;
        }

        mouseOverBox.transform.position = new Vector3(mousePosX, mousePosY, 0);
         mouseOverSpellnameText.text = "" + spellgemName;
        mouseOverLevelText.text = "" + level;
        mouseOverSchoolText.text = "" + school;
    }

    public void DisableMouseover()
    {
        mouseOverBox.SetActive(false);
    }




}
