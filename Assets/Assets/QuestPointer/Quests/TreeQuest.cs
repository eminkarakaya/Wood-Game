using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeQuest : Quest
{
    TreeBase tree;
    private void OnEnable()
    {
        questObject = this.gameObject;
        tree = GetComponent<Tree>();
        tree.onDestroyTree += Trigger;
    }
    private void OnDisable()
    {
        
        tree.onDestroyTree -= Trigger;
    }
    protected override void Trigger()
    {
        if (QuestManager.Instance.CheckCurrentQuest(this))
        {
            QuestManager.Instance.RemoveQuest(this);
        }
    }
}
