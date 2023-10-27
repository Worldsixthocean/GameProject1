using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PositionManager posManager;
    int posXIdx;
    int splitNum;

    // setup initial player position && some other variables
    void Start()
    {
        splitNum = posManager.GetSplitNum();
        posXIdx = splitNum / 2;
        float x = posManager.GetPositionX(posXIdx);
        float y = -posManager.GetCamHalfHeight() * 0.2f;
        this.transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        // move player left/right
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                && !(posXIdx - 1 < 0))
        {
            --posXIdx;
            float x = posManager.GetPositionX(posXIdx);
            float y = this.transform.position.y;
            this.transform.position = new Vector3(x, y, 0);
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                && !(posXIdx + 1 >= splitNum))
        {
            ++posXIdx;
            float x = posManager.GetPositionX(posXIdx);
            float y = this.transform.position.y;
            this.transform.position = new Vector3(x, y, 0);
        }

        // serve the dish
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) 
                || Input.GetKeyDown(KeyCode.Space))
        {
            serveDish(posXIdx);
        }
    }

    void serveDish(int idx)
    {
        // To be done:
        // check whether serve correct dish
        // if wrong -> reduce HP
        // else -> add score
    }
}
