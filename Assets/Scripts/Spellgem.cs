using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Spellgem : IComparable<Spellgem>
{
    //Fields
    public int id;
    public int level;
    public string name;
    public string school;
    public string god;

    //Constructor

    public Spellgem (Spellgem import)
    {
        this.id = import.id;
        this.level = import.level;
        this.name = import.name;
        this.school = import.school;
        this.god = import.god;
    }

   public int CompareTo (Spellgem other)
    {
        if (other == null)
        {
            return 1;
        }

        return id - other.id;
    }
}
