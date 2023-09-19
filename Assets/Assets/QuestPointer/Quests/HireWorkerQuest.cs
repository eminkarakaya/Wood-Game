using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireWorkerQuest : Quest
{
    FillAmountPlace fill;
    private void OnEnable()
    {
        questObject = this.gameObject;
        fill = GetComponent<FillAmountPlace>();
        fill.onFill += Trigger;
    }
    private void OnDisable()
    {
        fill.onFill -= Trigger;
        
    }
    protected override void Trigger()
    {
        if (QuestManager.Instance.CheckCurrentQuest(this))
        {
            QuestManager.Instance.RemoveQuest(this);
        }
    }
}
