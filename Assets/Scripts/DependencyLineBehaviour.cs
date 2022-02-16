using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyLineBehaviour : MonoBehaviour
{
    //Fields
    [SerializeField] GameObject spellgem1;
    [SerializeField] GameObject spellgem2;

    // Start is called before the first frame update
    void Start()
    {
        ScaleBetween();
        
    }

    // Update is called once per frame
    void Update()
    {
        RequirementMet();
    }

    public void ScaleBetween ()
    {
        Vector3 gem1Pos = spellgem1.transform.position;
        Vector3 gem2Pos = spellgem2.transform.position;
        float distance;

        //Moves line to the midway position between the two gems
        gameObject.transform.position = new Vector2((gem1Pos.x + gem2Pos.x)/2, (gem1Pos.y + gem2Pos.y) / 2);

        //Rotates the line to point at the first gem
        gameObject.transform.up = gem1Pos - transform.position;

        //Scales the y of the line to match distance between the gems
        distance = Vector3.Distance(gem1Pos, gem2Pos);
        gameObject.transform.localScale = new Vector3(0.1f, (distance / 2), 1);
    }

    public void RequirementMet ()
    {
        if (spellgem1.GetComponent<SpellgemBehavior>().isLearned == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.5f, 0, 0.75f);
            spellgem2.GetComponent<SpellgemBehavior>().requirementMet = true;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0, 0.75f);
        }
    }
}
