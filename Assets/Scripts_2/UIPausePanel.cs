using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPausePanel : MonoBehaviour
{
    [SerializeField] GameObject panelBG = null;
    [SerializeField] RectTransform panelElement = null;
    [SerializeField] Transform animationPosition = null;
    [SerializeField] float transitionTime = 0.5f;

    void Awake() 
    {
        ClosePanel();
    }
    
    public void OpenPanel() 
    {
        panelBG.SetActive(true);
        StartCoroutine(DoAnimation());
    }

    public void ClosePanel() 
    {
        panelBG.SetActive(false);
        panelElement.gameObject.SetActive(false);
    }

    public void ResetButtom() 
    {
        GameManager.Instance.ResetScene();
    }

    public void ExitButtom()
    {
        GameManager.Instance.LoadWorld1();
    }

    IEnumerator DoAnimation() 
    {
        panelElement.gameObject.SetActive(true);
        Vector2 __startPosition = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelElement, animationPosition.position, null, out __startPosition);
        __startPosition = __startPosition + Vector2.up * panelElement.rect.height / 2;
        
        float __timer = 0;
        panelElement.anchoredPosition = __startPosition;
        while (__timer < transitionTime) 
        {
            float __rate = __timer / transitionTime;
            __rate = 1 - __rate;
            __rate = __rate * __rate * __rate;
            __rate = 1 - __rate;
            panelElement.anchoredPosition = Vector2.Lerp(__startPosition, Vector2.zero, __rate);
            yield return null;
            __timer += Time.deltaTime;
        }
        panelElement.anchoredPosition = Vector2.zero;
    }
}
