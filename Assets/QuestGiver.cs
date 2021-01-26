using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI experienceText;
    
    public void OpenQuestWindow()
    {
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = "Reward: "+quest.experienceReward+" SP.";
        questWindow.SetActive(true);
        
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.currentQuest = quest;
    }
}
