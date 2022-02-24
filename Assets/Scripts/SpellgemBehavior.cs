using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellgemBehavior : MonoBehaviour
{

    //Fields
    public int id;
    public int level;
    public string name;
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
    [SerializeField] private GameObject learnedToken;



    //Constructor
    public SpellgemBehavior(int id, int level, string name, string school, string god)
    {
        this.id = id;
        this.level = level;
        this.name = name;
        this.school = school;
        this.god = god;
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
            UIController.learnedSpellIDs.Add(this.id);
            GameObject.Find("UI Controller").GetComponent<UIController>().AddToMasteryCount(this.school);

        } else
        {
            UIController.learnedSpellIDs.Remove(this.id);
            GameObject.Find("UI Controller").GetComponent<UIController>().RemoveFromMasteryCount(this.school);

        }

    }

    public void ToggleLearned()
    {
        if (isLearned == false && requirementMet == true)
        {
            SetLearned(true);

            
        }
        else
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



}
