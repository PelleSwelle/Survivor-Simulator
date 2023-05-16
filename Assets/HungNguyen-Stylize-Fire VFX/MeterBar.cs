using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterBar : MonoBehaviour
{
    [SerializeField] TMP_Text amountText;
    public RectTransform barRectTransform;
    public float value;

    float position;
    Vector2 endPosition;
    [SerializeField] float startWidth;

    void Awake() => startWidth = 204;

    void Update()
    {
        updateText();
        updateBar();
    }

    void updateBar()
    {
        position = Util.mapRange(100, 0, startWidth, 0, value);
        barRectTransform.offsetMax = new Vector2(position, barRectTransform.offsetMax.y);
    }

    void updateText()
    {
        int roundedValue = (int) value;
        amountText.SetText(roundedValue.ToString());
    }
}
