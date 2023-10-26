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
    [SerializeField] private float time;
    [SerializeField] private bool timerActive = false;
    [SerializeField] private bool isCountingDown = false;
    [SerializeField] RectTransform _hp;
    [SerializeField] Text _timeText;

    void Start()
    {
    }

    public void AddHP(int HPArg = 10) { 
        if (isCountingDown) 
            HP = (HP + HPArg > MaxHP) ? MaxHP : (HP + HPArg);
    }

    public void StartTimer(int timeArg = 10) {
        if (!timerActive){
            HP = MaxHP;
            time = timeArg;
            timerActive = true;
            isCountingDown = true;
            _timeText.text = time < 10 ? ("0" + Mathf.CeilToInt(time).ToString()) : time.ToString();
        }
    }

    public void ToggleTimer() {
        if (isCountingDown) PauseTimer(); else ResumeTimer();
    }

    public void PauseTimer() {
        isCountingDown = false;
    }

    public void ResumeTimer(){
        isCountingDown = timerActive ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown && HP > 0 && time > 0)
        {
            HP -= HPchange * Time.deltaTime;
            time -= Time.deltaTime;
            int IntTime = Mathf.CeilToInt(time);
            _timeText.text = IntTime < 10 ? ("0" + IntTime.ToString()) : IntTime.ToString();
        }
        else if (!isCountingDown) {
        
        }
        else{
            isCountingDown = false;
            timerActive = false;
            if (HP > 0) {
                Debug.Log("Time's up");
            }
            else {
                Debug.Log("Lose");
            }
        }
        _hp.GetComponent<RectTransform>().localScale = new Vector3(HP / MaxHP,1,1);
    }
}
