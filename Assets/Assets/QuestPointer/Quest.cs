using System.Collections;
using System.Linq;
using UnityEngine;
public abstract class Quest : MonoBehaviour
{
    bool isComplated;
    public GameObject questObject;
    private void Awake()
    {
        if (isComplated)
            QuestManager.Instance.RemoveQuest(this);
    }
    public IEnumerator QuestAnimation()
    {
        while (true)
        {
            yield return null;
            if (Movement.Instance != null)
            {
                Movement.Instance.isAnim = true;
                break;
            }
        }
        yield return new WaitForSeconds(1f);
        CameraFollow.instance.followObject = questObject;
        QuestPointer.Instance.ToggleQuestPointer(true);
        QuestPointer.Instance.SetTargetQuestPoint(questObject.transform);

        OutlineOn();
        yield return new WaitForSeconds(2f);
        CameraFollow.instance.followObject = Movement.Instance.gameObject;
        while (true)
        {
            yield return null;
            if (Movement.Instance != null)
            {
                Movement.Instance.isAnim = false;
                break;
            }
        }
    }
    void OutlineOn()
    {
        QuickOutline [] outlines = questObject.GetComponentsInChildren<MeshRenderer>().Where(x=>!x.TryGetComponent(out QuickOutline outline)).Select(x=>x.gameObject.AddComponent(typeof(QuickOutline)) as QuickOutline).ToArray();
        outlines.Select(x => x.OutlineColor = Color.green);
    }
    void OutlineOff()
    {
        QuickOutline[] outlines = questObject.GetComponentsInChildren<QuickOutline>();
        foreach (var item in outlines)
        {
            item.enabled = false;
        }
    }
    protected abstract void Trigger();
}