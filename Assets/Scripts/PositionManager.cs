using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    int splitNum;
    List<float> positionsX = new List<float>();

    Camera cam;
    float camHalfHeight;
    float camHalfWidth;
    float marginX = 0.6f;   // most left/right edge of splits

    // Setup camera size && each split position
    public void Setup(int _splitNum)
    {
        this.splitNum = _splitNum;

        cam = GameObject.FindObjectOfType<Camera>();
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;

        // setup each split position and save them into positionsX(a List of float)
        float currX = -camHalfWidth * marginX;
        for (int i = 0; i < splitNum; ++i)
        {
            positionsX.Add(currX);
            currX += camHalfWidth * marginX * 2 / (splitNum - 1);
        }
    }

    public float GetPositionX(int idx)
    {
        return this.positionsX[idx];
    }

    public int GetSplitNum()
    {
        return this.splitNum;
    }

    public float GetCamHalfHeight()
    {
        return this.camHalfHeight;
    }
}
