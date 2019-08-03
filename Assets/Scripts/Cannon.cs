using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    // Update is called once per frame
    private Constants.Type selectedColor = Constants.Type.RED;
    void Update()
    {

        if (Input.GetButtonDown("Fire")) {
            Shoot();
        }
        if (Input.GetButtonDown("NextBall")) {
            SwitchToNextBall();
        }
        if(Input.GetButtonDown("PreviousBall")) {
            SwitchToPreviousBall();
        }
    }

    private void SwitchToPreviousBall() {
        switch (selectedColor) {
            case Constants.Type.RED:
                selectedColor = Constants.Type.GREEN;
                break;
            case Constants.Type.BLUE:
                selectedColor = Constants.Type.RED;
                break;
            case Constants.Type.GREEN:
                selectedColor = Constants.Type.BLUE;
                break;
            default:
                break;
        }
    }

    private void SwitchToNextBall() {
        switch(selectedColor) {
            case Constants.Type.RED:
                selectedColor = Constants.Type.BLUE;
                break;
            case Constants.Type.BLUE:
                selectedColor = Constants.Type.GREEN;
                break;
            case Constants.Type.GREEN:
                selectedColor = Constants.Type.RED;
                break;
            default:
                break;
        }
    }

    private void Shoot() {
        Debug.Log("Canhao atirou uma bola");
        switch (selectedColor) {
            case Constants.Type.RED:
                Debug.Log("vermelha");
                break;
            case Constants.Type.BLUE:
                Debug.Log("azul");
                break;
            case Constants.Type.GREEN:
                Debug.Log("verde");
                break;
            default:
                break;
        }
    }
}
