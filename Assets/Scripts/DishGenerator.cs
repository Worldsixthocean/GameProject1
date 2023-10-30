using System.Collections.Generic;
using UnityEngine;

public class DishGenerator : MonoBehaviour
{
    public PositionManager posManager;
    public List<GameObject> dish_sprites;

    void Start()
    {
        this.GenerateDish();
    }

    public void GenerateDish()
    {
        int dishNum = dish_sprites.Count;
        posManager.Setup(dishNum);

        // instantiate n dishes, where n = dishNum
        for (int i = 0; i < dishNum; ++i)
        {
            float x = posManager.GetPositionX(i);
            float y = -posManager.GetCamHalfHeight() * 0.6f;
            GameObject dish = dish_sprites[i];

            dish.transform.position = new Vector3(x, y, 0);
            Instantiate(dish);
        }
    }
}
