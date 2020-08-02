using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerScript : MonoBehaviour {

    public CarScript leftCarScript;
    public CarScript rightCarScript;

    void Update() {
        if (GameStatusScripts.gameRunning) {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                leftCarScript.ChangeLane();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                rightCarScript.ChangeLane();
            }
        }
    }
}
