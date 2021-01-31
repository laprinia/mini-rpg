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

    public void Complete(String text)
    {
        isActive = false;
        GameObject.Destroy(questGiver);
        descriptionText.text = text;
        okButton.onClick.AddListener(OnClickOK);
        questWindow.SetActive(true);
        
    }

    public void OnClickOK()
    {
        questWindow.SetActive(false);
    }
}
