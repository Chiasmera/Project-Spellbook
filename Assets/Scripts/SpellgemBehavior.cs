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
    private bool isLearned;

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



    //Other Methods
    public void SetSchoolColor()
    {
        switch (school)
        {
            case "Abjuration":
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case "Illusion":
                this.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 1, 1);
                break;
            case "Conjuration":
                this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.64f, 0.0f, 1.0f);
                break;
            case "Enchantment":
                this.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case "Evocation":
                this.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case "Divination":
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "Necromancy":
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "Transmutation":
                this.GetComponent<SpriteRenderer>().color = Color.green;
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
        if (isLearned == false)
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
