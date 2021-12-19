using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;

    private float targetAlpha = 0;
    public float smoothing = 6;

    void Start()
    {
        toolTipText = GetComponent<Text>();
        contentText = transform.Find("Content").GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(canvasGroup.alpha != targetAlpha)
        {
             canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha,smoothing * Time.deltaTime);
            if(Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.05f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public void Show(string text)
    {
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
    }

    public void Hide()
    {
        targetAlpha = 0;
    }

    public void SetLocalPosition(Vector3 position)
    {
        transform.localPosition = position;
    }
}
