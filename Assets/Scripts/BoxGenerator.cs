using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public int boxNum = 5;
    public GameObject boxTemplate;
    public PositionManager posManager;

    void Start()
    {
        posManager.Setup(boxNum);

        // instantiate n boxes, where n = boxNum
        for (int i = 0; i < boxNum; ++i)
        {
            float x = posManager.GetPositionX(i);
            float y = -posManager.GetCamHalfHeight() * 0.6f;
            boxTemplate.transform.position = new Vector3(x, y, 0);
            Instantiate(boxTemplate);
        }
    }
}
