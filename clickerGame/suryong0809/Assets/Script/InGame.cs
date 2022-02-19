using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InGame : MonoBehaviour
{
    public long money;  // 현재 소지금
    public long moneyIncreaseAmount; // 소지금 증가량
    public long autoIncreaseAmount; // 자동 소지금 증가량

    public Text textmoney;  // 텍스트 표시하는 부분
    public Text automoney;  // 자동 증가량 표시

    effectSoundManager effectSM;

    void Start()
    {
        money = 0;
        moneyIncreaseAmount = 1;
        autoIncreaseAmount = 0;

        StartCoroutine(co_timer());     //소지금 자동 증가 함수

        effectSM = GameObject.Find("Script").GetComponent<effectSoundManager>();
    }
    void Update()
    {
        ShowInfo();         // 소지금 표시 함수
        MoneyIncrease();    // 소지금 증가 함수
    }

    // 1. 소지금 증가 함수
    void MoneyIncrease()
    {
        if (Input.GetMouseButtonDown(0))    // 클릭 입력 들어오면
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {   // UI 터치==false면 (UI를 터치한 게 아니라면)
                money += moneyIncreaseAmount;    // 소지금=소지금+증가량
                effectSM.PlaySound("Touch");
            }
        }
    }

    // 소지금 자동 증가 함수
    IEnumerator co_timer()
    {
        while (true)
        {
            if (autoIncreaseAmount > 0)
            {
                money += autoIncreaseAmount; //증가량이 0보다 큰 경우, 증가량만큼 더해주기.
            }
            yield return new WaitForSeconds(1f); //1초 딜레이 주기
        }
    }


    // 2-1. 소지금 표시 함수
    void ShowInfo()
    {
        long kmoney = money / 1000;
        long kmoney2 = money % 1000;
        long mmoney = money / 1000000;
        long mmoney2 = money % 1000000 / 100000;
        if (money == 0) // 돈이 0이면 "0 수정" 표기
            textmoney.text = "0";
        else
        {
            if (kmoney!=0 && mmoney==0)
            {
                textmoney.text = GetThousandCommaText(kmoney)+"."+kmoney2.ToString()+"K";
            }
            else if (mmoney != 0)
            {
                textmoney.text = GetThousandCommaText(mmoney) + "."+mmoney2.ToString()+"M";
            }
            else
                textmoney.text = GetThousandCommaText(money);
        }
        if (autoIncreaseAmount == 0)
            automoney.text = "+ 0";
        else
            automoney.text = "+ "+GetThousandCommaText(autoIncreaseAmount);
    }
    // 2-2. 천단위로 콤마(,) 찍어주는 정규식
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
