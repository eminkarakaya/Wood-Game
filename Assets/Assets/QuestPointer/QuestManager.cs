using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] private List<Quest> quests = new List<Quest>();

    private void Start()
    {
        StartCoroutine(quests[0].QuestAnimation());
    }
    public void RemoveQuest(Quest quest)
    {
        quest.enabled = false;
        if(quests.Contains(quest))
        {
            quests.Remove(quest);
        }
        if(quests.Count > 0)
        {
            StartCoroutine(quests[0].QuestAnimation());
        }
        else
        {
            QuestPointer.Instance.ToggleQuestPointer(false);
        }
    }
    public void AddQuest(Quest quest)
    {
        if (!quests.Contains(quest))
        {
            quests.Add(quest);
        }
    }
    public bool CheckCurrentQuest(Quest quest)
    {
        return quests[0] == quest;
    }
}


