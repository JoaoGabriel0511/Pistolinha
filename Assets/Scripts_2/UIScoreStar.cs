using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreStar : MonoBehaviour
{
    [SerializeField] Image starImage = null;
    [SerializeField] Sprite emptySprite = null;
    [SerializeField] Sprite fullSprite = null;

    public void SetStar(bool p_isFull) 
    {
        starImage.sprite = p_isFull ? fullSprite : emptySprite;
    }
}
