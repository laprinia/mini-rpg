using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue mainDialogue;
    public Dialogue questDialogue;
    public Dialogue conversateDialogue;
    public Dialogue denyQuestDialogue;
    public Dialogue acceptQuestDialogue;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(mainDialogue,"Ask her about her daughter","Ask about quest");
        DialogueManager.instance.getFirstButton().onClick.AddListener(onClickConversate);
        DialogueManager.instance.getSecondButton().onClick.AddListener(onCLickQuest);
    }

    public void onCLickQuest()
    {
       DialogueManager.instance.StartDialogue(questDialogue,"Accept","Deny");
       DialogueManager.instance.getFirstButton().onClick.AddListener(onClickAccept);
       DialogueManager.instance.getSecondButton().onClick.AddListener(onClickDeny);
       
    }

    public void onClickConversate()
    {
       DialogueManager.instance.StartDialogue(conversateDialogue,null,null);
    }
    public void onClickAccept()
    {
       DialogueManager.instance.StartDialogue(acceptQuestDialogue,null,null);
       //todo start quest syst
    }

    public void onClickDeny()
    {
       DialogueManager.instance.StartDialogue(denyQuestDialogue,null,null);
    }
}
