using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyLineBehaviour : MonoBehaviour
{
    //Fields
    [SerializeField] GameObject spellgem1;
    [SerializeField] GameObject spellgem2;
    [SerializeField] Sprite connectorRed;
    [SerializeField] Sprite connectorGreen;

    // Start is called before the first frame update
    void Start()
    {
        ScaleBetween();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRequirement();
    }

    public void ScaleBetween ()
    {
        Vector2 gem1Pos = spellgem1.transform.position;
        Vector2 gem2Pos = spellgem2.transform.position;
        float distance;

        //Moves line to the midway position between the two gems
        gameObject.transform.position = new Vector2((gem1Pos.x + gem2Pos.x)/2, (gem1Pos.y + gem2Pos.y) / 2);

        //Rotates the line to point at the second gem
        transform.up = gem2Pos - new Vector2(transform.position.x, transform.position.y);



        //Scales the y of the line to match distance between the gems
        distance = Vector3.Distance(gem1Pos, gem2Pos);
        gameObject.transform.localScale = new Vector3(0.1f, (distance / 5 ), 1);
        gameObject.transform.Rotate(0, 0, transform.rotation.z);
    }

    public void CheckRequirement ()
    {
        if (spellgem1.GetComponent<SpellgemBehavior>().isLearned == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = connectorGreen;
            spellgem2.GetComponent<SpellgemBehavior>().requirementMet = true;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = connectorRed;
            spellgem2.GetComponent<SpellgemBehavior>().requirementMet = false;
        }
    }
}
