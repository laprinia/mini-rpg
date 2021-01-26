using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Quest
{
    public Button okButton;
    public GameObject questWindow;
    public TextMeshProUGUI descriptionText;
    public GameObject questGiver;
    public QuestGoal Goal;
    public bool isActive;
    public string title;
    public string description;
    public int experienceReward;

    public void Complete()
    {
        
        //todo show canvas
        isActive = false;
        GameObject.Destroy(questGiver);
        descriptionText.text = "You completed the quest! Mieruki is at peace and can depart now";
        okButton.onClick.AddListener(OnClickOK);
        questWindow.SetActive(true);
        
    }

    public void OnClickOK()
    {
        questWindow.SetActive(false);
    }
}
