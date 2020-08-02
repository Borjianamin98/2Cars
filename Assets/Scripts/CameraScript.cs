using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public SpriteRenderer mainSprite;
    void Start() {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float mainSpriteRatio = (float)mainSprite.bounds.size.x / (float)mainSprite.bounds.size.y;

        if (screenRatio >= mainSpriteRatio) {
            Camera.main.orthographicSize = mainSprite.bounds.size.y / 2;
        } else {
            float difference = mainSpriteRatio / screenRatio;
            Camera.main.orthographicSize = mainSprite.bounds.size.y / 2 * difference;
        }
    }

}
