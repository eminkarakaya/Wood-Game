using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public abstract class DropPlaceBase : MonoBehaviour
{
    public TextMeshPro text;
    public int max, current;
    private float _width, _height;
    public float time;
    private void Start()
    {
        _width = this.GetComponent<RectTransform>().rect.width;
        _height = this.GetComponent<RectTransform>().rect.height;
        GetComponent<BoxCollider>().size = new Vector3(_width, _height, 200);
    }
    public void SetCurrent(int value)
    {
        current += value;
        if(text != null)
            text.text = current.ToString() + "/" + max.ToString();
    }
    public bool IsFull()
    {
        if (current == max)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public abstract Vector3 GetAvailablePlace();
}
