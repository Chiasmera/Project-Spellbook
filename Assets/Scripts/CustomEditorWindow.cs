using UnityEngine;
using UnityEditor;

public class EditModeFunctions : EditorWindow
{
    [MenuItem("Window/Edit Mode Functions")]
    public static void ShowWindow()
    {
        GetWindow<EditModeFunctions>("Edit Mode Functions");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Populate spellgems"))
        {
            GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().LoadSpellListData();
            GameObject.Find("SpellDatabase").GetComponent<LoadCSV>().spellgemDatabase.Sort();
            GameObject.Find("GameController").GetComponent<GameController>().PopulateSpellgems();
        }
    }

    private void FunctionToRun()
    {
        Debug.Log("The function ran.");
    }
}