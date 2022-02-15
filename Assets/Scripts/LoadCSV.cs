using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCSV : MonoBehaviour
{
    public Spellgem blankSpellgem;
    public List<Spellgem> spellgemDatabase = new List<Spellgem>();

    public void LoadSpellListData ()
    {
        //Clear Database
        spellgemDatabase.Clear();

        //Read CSV File
        List<Dictionary<string, object>> data = CSVReader.Read("SpellDatabase");
        for (var i = 0; i < data.Count; i++)
        {
            int id = int.Parse(data[i]["id"].ToString(), System.Globalization.NumberStyles.Integer);
            int level = int.Parse(data[i]["level"].ToString(), System.Globalization.NumberStyles.Integer);
            string name = data[i]["name"].ToString();
            string school = data[i]["school"].ToString();
            string god = data[i]["god"].ToString();

            AddSpellgem(id, level, name, school, god);
        }
    }

    void AddSpellgem(int id, int level, string name, string school, string god)
    {
        Spellgem tempSpellgem = new Spellgem(blankSpellgem);

        tempSpellgem.id = id;
        tempSpellgem.level = level;
        tempSpellgem.name = name;
        tempSpellgem.school = school;
        tempSpellgem.god = god;

        spellgemDatabase.Add(tempSpellgem);
       
    }

}
