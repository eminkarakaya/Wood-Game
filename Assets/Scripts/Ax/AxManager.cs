using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxManager : Singleton<AxManager> 
{
    public Vector3 pos;
    public Vector3 rot;
    [SerializeField] private List<Ax> axes;
    public Ax currentAx;
    public int currentAxIndex;
    [SerializeField] private Transform hand;
    private void OnEnable()
    {
        LoadData();
    }
    private void OnDisable()
    {
        SaveData();
    }
    public void ChangeAx(Ax ax)
    {
        
        Destroy(currentAx.gameObject);
        currentAx = ax;
        ax.transform.parent = hand;
        ax.transform.localRotation = Quaternion.Euler(rot);
        ax.transform.localPosition = pos;
        currentAxIndex = currentAx.axData.index;
    }
    
    public void LoadData()
    {
        currentAxIndex = PlayerPrefs.GetInt("AxIndex");
    }

    public void SaveData()
    {
        
        PlayerPrefs.SetInt("AxIndex", currentAxIndex);
    }

    public Ax InstantiateCurrentAx()
    {
        var obj = Instantiate(axes[currentAxIndex]);
        hand = Movement.Instance.hand;
        obj.transform.SetParent(hand);
        obj.transform.localPosition = pos;
        obj.transform.localRotation = Quaternion.Euler(rot);
        currentAx = obj;
        return obj;
    }
}
