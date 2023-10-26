using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;
using System.Data;

public class HPTimeBar : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private int MaxHP;
    [SerializeField] private int HPchange;
    [SerializeField] private int time;
    [SerializeField] private bool isCountingDown = false;
    [SerializeField] RectTransform _hp;
    [SerializeField] Text _timeText;

    void Start()
    {
    }

    public void AddHP(int HPArg) { 
        if (isCountingDown) 
            HP = (HP + HPArg > MaxHP) ? MaxHP : (HP + HPArg);
    }

    public void StartTimer(int timeArg) {
        HP = MaxHP;
        time = timeArg;
        isCountingDown = true;
        _timeText.text = time < 10 ? ("0" + time.ToString()) : time.ToString();
        Invoke("Tick", 1f);
    }

    void Tick() {
        if (time > 0 && isCountingDown == true) {
            time--;
            _timeText.text = time < 10 ? ("0" + time.ToString()) : time.ToString();
            Invoke("Tick", 1f);
        }
        else {
            isCountingDown = false;
            //finished
            }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown && HP >= 0)
        {
            HP -= HPchange * Time.deltaTime;
        }
        else if( HP <= 0)
        {
            isCountingDown = false;
            //lose
        }
        _hp.GetComponent<RectTransform>().localScale = new Vector3(HP / MaxHP,1,1);
    }
}
