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
        Outline [] outlines = questObject.GetComponentsInChildren<MeshRenderer>().Where(x=>!x.TryGetComponent(out Outline outline)).Select(x=>x.gameObject.AddComponent(typeof(Outline)) as Outline).ToArray();
        outlines.Select(x => x.OutlineColor = Color.green);
    }
    void OutlineOff()
    {
        Outline[] outlines = questObject.GetComponentsInChildren<Outline>();
        foreach (var item in outlines)
        {
            item.enabled = false;
        }
    }
    protected abstract void Trigger();
}