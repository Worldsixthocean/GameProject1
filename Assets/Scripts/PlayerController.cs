using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PositionManager posManager;
    int posXIdx;
    int splitNum;
    int selectedDishId;
    bool readyToServe;

    void Start()
    {
        this.Setup();
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            // serve the dish
            if (readyToServe && posXIdx == splitNum-1)
            {
                serveDish(selectedDishId);
                readyToServe = false;
            }
            else if (posXIdx != splitNum-1) // select/hold the dish
            {
                selectDish(posXIdx);
                readyToServe = true;
            }
            else
            {
                print("No dish selected and served!");
            }
        }
    }

    public void Setup() 
    {
        readyToServe = false;

        splitNum = posManager.GetSplitNum();
        posXIdx = splitNum / 2;
        float x = posManager.GetPositionX(posXIdx);
        float y = -posManager.GetCamHalfHeight() * 0.2f;
        this.transform.position = new Vector3(x, y, 0);
    }

    void serveDish(int dishId)
    {
        print($"served dish no.{dishId}");
        // To be done:
        // check whether serve correct dish
        // if wrong -> reduce HP
        // else -> add score
    }

    void selectDish(int dishId)
    {
        print($"selected dish no.{dishId}");
        this.selectedDishId = dishId;
        // To be done:
    }
}
