using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeCamForTiles : MonoBehaviour
{
    public float HardcodedRatioWidth;
    public float HardcodedRatioHeight;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        resizeCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resizeCamera() {
        var PrevWidth = Screen.width;
        var PrevHeight = Screen.height;

        float screenRatio = PrevWidth / PrevHeight;
        float relativeWidth = HardcodedRatioWidth / PrevWidth;
        float relativeHeight = HardcodedRatioHeight / PrevHeight;

        if (screenRatio < HardcodedRatioWidth / HardcodedRatioHeight) {
            var hAdjustment = relativeHeight / relativeWidth;
            var yAdjustment = (1 - hAdjustment) / 2;
            this.cam.rect = new Rect(0, yAdjustment, 1, hAdjustment);
        } else {
            var wAdjustment = relativeWidth / relativeHeight;
            var xAdjustment = (1 - wAdjustment) / 2;
            this.cam.rect = new Rect(xAdjustment, 0, wAdjustment, 1);
        }
    }
}
