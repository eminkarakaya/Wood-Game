using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagDropQuest : Quest
{
    int temp = 0;
    DropFromBagDestroy drop;
    private void OnEnable()
    {
        questObject = this.gameObject;
        drop = GetComponent<DropFromBagDestroy>();
        drop.onDrop += Trigger;
        
    }
    private void OnDisable()
    {
        drop.onDrop -= Trigger;
        
    }
    protected override void Trigger()
    {
        if(QuestManager.Instance.CheckCurrentQuest(this))
        {
            temp++;
            if(temp == 5)
            {
                QuestManager.Instance.RemoveQuest(this);
            }
        }
    }
}
