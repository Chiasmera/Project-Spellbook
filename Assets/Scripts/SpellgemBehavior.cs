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

    //Constructor
    public SpellgemBehavior(int id, int level, string name, string school, string god)
    {
        this.id = id;
        this.level = level;
        this.name = name;
        this.school = school;
        this.god = god;
    }


    // Start is called before the first frame update
    void Start()
    {
        
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

}
