using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().LoadSpellListData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
