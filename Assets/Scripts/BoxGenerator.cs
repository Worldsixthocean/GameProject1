using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public int boxNum = 5;
    public GameObject boxTemplate;
    public List<GameObject> boxes;

    void Start()
    {
        Camera cam = GameObject.FindObjectOfType<Camera>();
        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;

        float marginX = 0.6f;
        float marginY = 0.6f;
        float currX = -cameraWidth * marginX;
        float currY = -cameraHeight * marginY;

        for (int i = 0; i < boxNum; ++i)
        {
            Instantiate(boxTemplate);
            boxTemplate.transform.position = new Vector3(currX, currY, 0);
            boxes.Add(boxTemplate);
            currX += cameraWidth * marginX * 2 / (boxNum - 1);
        }
    }
}
