using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;
public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }
    private const string saveVariablesKey = "INK_VARIABLES";
    private Story globalVariablesStory;
    private string selectedProfileId;
    public DialogueVariables(TextAsset loadGlobalsJSON)
    {
        //compile the story
        // string inkFileContents = File.ReadAllText(globalsFilePath);
        // Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        // Ink.Compiler compiler = gameObject.AddComponent<Ink.Compiler>(glo);
        // Story globalVariablesStory = compiler.Compile();

        //create the story
        globalVariablesStory = new Story(loadGlobalsJSON.text);
        //if we have saved data then load it
        selectedProfileId = DataPersistenceManager.instance.selectedProfileId;
        if (PlayerPrefs.HasKey(saveVariablesKey + selectedProfileId) && !DataPersistenceManager.instance.disableDataPersistence)
        {
            Debug.Log("load dialogue save from: " + saveVariablesKey + DataPersistenceManager.instance.selectedProfileId);
            string jsonState = PlayerPrefs.GetString(saveVariablesKey + selectedProfileId);
            globalVariablesStory.state.LoadJson(jsonState);
        }
        // globalVariablesStory.variablesState["name"] = "testst";

        //initialize the dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initailized global dialogue variable: " + name + " = " + value);
        }
    }
    public void SetVariableState(string name, Ink.Runtime.Value value)
    {
        // globalVariablesStory.variablesState[name] = value;
        VariableChanged(name, value);
        // globalVariablesStory.variablesState.SetGlobal(name, value);
        // Debug.Log(name + " = "+value);

    }
    public void SaveVariables()
    {
        if (globalVariablesStory != null)
        {
            //load current state of all our variables to globals story
            VariablesToStory(globalVariablesStory);
            if (!DataPersistenceManager.instance.disableDataPersistence) PlayerPrefs.SetString(saveVariablesKey + selectedProfileId, globalVariablesStory.state.ToJson());
        }
    }
    public void StartListenning(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }
    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
        Debug.Log("Variable changed: " + name + " = " + value);
    }
    private void VariablesToStory(Story story)
    {
        // Debug.Log("Variable To Story");
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
            // Debug.Log("Variable To Story: name = " + variable.Key + " value = " + variable.Value);
        }
    }
}
