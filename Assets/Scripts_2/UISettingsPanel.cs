using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsPanel : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    
    void Awake() 
    {
        ClosePanel();
    }
    
    public void OpenPanel() 
    {
        volumeSlider.value = SoundManager.Instance.GetMasterVolume();
        gameObject.SetActive(true);
    }

    public void ClosePanel() 
    {
        gameObject.SetActive(false);
    }

    public void SetSound(float p_volume) 
    {
        SoundManager.Instance.SetMasterVolume(p_volume);
    }

    public void ResetGameData() 
    {
        GameManager.Instance.ClearProgress();
        GameManager.Instance.LoadTitleScreen();
    }

    public void CreditScreen() 
    {
        GameManager.Instance.LoadCredits();
    }
}
