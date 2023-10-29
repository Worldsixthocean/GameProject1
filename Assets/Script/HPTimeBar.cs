using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;
using System.Data;

public class HPTimeBar : MonoBehaviour
{
    //現時HP值
    [SerializeField] private float HP;
    //最大HP值
    [SerializeField] private int MaxHP;
    //HP隨著時間的過去而減少的速度(每秒)
    [SerializeField] private int HPchange;
    //剩餘時間(秒)
    [SerializeField] private float time;
    /*如果為True,倒數計時正在進行或者暫停
    如果為False,倒數計時正停止*/
    [SerializeField] private bool timerActive = false;
    /*如果為True,倒數計時正在進行
    如果為False,倒數計時正在暫停/停止*/
    [SerializeField] private bool isCountingDown = false;
    //HP Bar 移動的部分的RectTransform特性
    [SerializeField] RectTransform _hp;
    //倒數字 的Text特性 TextMeshPro
    [SerializeField] Text _timeText;

    void Start()
    {
    }

    //增加HP HPArg:增加多數量
    public void AddHP(int HPArg = 10) { 
        if (isCountingDown) 
            HP = (HP + HPArg > MaxHP) ? MaxHP : (HP + HPArg);
    }

    //開始倒數 timeArg:設定倒數時間
    public void StartTimer(int timeArg = 10) {
        if (!timerActive){
            HP = MaxHP;
            time = timeArg;
            timerActive = true;
            isCountingDown = true;
            _timeText.text = time < 10 ? ("0" + Mathf.CeilToInt(time).ToString()) : time.ToString();
        }
    }

    //暫停/恢復時間倒數
    public void ToggleTimer() {
        if (isCountingDown) PauseTimer(); else ResumeTimer();
    }

    //暫停時間倒數
    public void PauseTimer() {
        isCountingDown = false;
    }

    //恢復時間倒數(如果倒數已停止,則不會恢復
    public void ResumeTimer(){
        isCountingDown = timerActive ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        //如果沒有暫停倒數,而 HP 及時間未耗盡
        if (isCountingDown && HP > 0 && time > 0)
        {
            HP -= HPchange * Time.deltaTime;
            time -= Time.deltaTime;
            int IntTime = Mathf.CeilToInt(time);
            _timeText.text = IntTime < 10 ? ("0" + IntTime.ToString()) : IntTime.ToString();
        }
        //如果正暫停倒數/停止倒數(不做住何事
        else if (!isCountingDown) {
        
        }
        //如果沒有暫停倒數,但 HP 及時間已耗盡
        else{
            isCountingDown = false;
            timerActive = false;
            if (HP > 0) {
                Debug.Log("Time's up");
                //這個應該 call function 告訴玩家時間耗盡
            }
            else {
                Debug.Log("Lose");
                //這個應該 call function 告訴玩家輸掉
            }
        }
        //改變 HP Bar 長短
        _hp.GetComponent<RectTransform>().localScale = new Vector3(HP / MaxHP,1,1);
    }
}
