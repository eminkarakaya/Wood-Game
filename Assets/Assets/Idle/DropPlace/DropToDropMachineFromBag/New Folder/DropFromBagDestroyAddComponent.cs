using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromBagDestroyAddComponent : MonoBehaviour
{
    public DropFromBagDestroy dropFromBagDestroy;
    public float time;
    private void Start   ()
    {
        StartCoroutine(Fill(this.transform));
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator Fill(Transform other)
    {
        while (true)
        {
            yield return new WaitForSeconds(dropFromBagDestroy.dropMachine.time);

            var collectable = other.GetComponent<Drop>().DropItem(dropFromBagDestroy.collectableType);
            if (collectable != null)
            {
                var obj = collectable.gameObject;
                dropFromBagDestroy.Jump(obj, other);
                dropFromBagDestroy.dropMachine.SetCurrent(+1);
                //GameManager.Instance.SetWood(-1);
            }
        }
    }
}
