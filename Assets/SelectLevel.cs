﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.LoadScene("LevelSelection");
    }
}
