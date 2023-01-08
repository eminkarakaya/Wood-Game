using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillPlace : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public Image fillImage;
    public int max, current;
    private float _width, _height;
    public float timeOffset;
    private void Start()
    {
        _width = this.GetComponent<RectTransform>().rect.width;
        _height = this.GetComponent<RectTransform>().rect.height;
        GetComponent<BoxCollider>().size = new Vector3(_width, _height, 5);
    }
    public void SetCurrent()
    {
        current++;
        text.text = current.ToString();
    }
}
