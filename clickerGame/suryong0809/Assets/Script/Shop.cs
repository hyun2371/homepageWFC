using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{

    public long pCrystal;
    public long pRandom;
    public long pClick;
    public long pFever;
    public long pCats;

    public Text alertmsg;

    InGame ingame;
    changeSuryong changesuryong;
    effectSoundManager effectSM;
    int rnum;
    public int numOfCats;
    public GameObject[] cats = new GameObject[3]; //고양이 세 마리 연결하기!
    public GameObject alert;
    public GameObject fevertime;
    bool isFever;
    long tmp;
    public GameObject shopobj;

    public Text pCrystalText;
    public Text pRandomText;
    public Text pClickText;
    public Text pFeverText;
    public Text pCatsText;

    void Start()
    {

        pCrystal = 10;   // 처음 가격 임의 설정. 나중에 수정 필요
        pRandom = 10;
        pClick = 10;
        pFever = 10;
        pCats = 50;
        numOfCats = 3;
        isFever = false;

        // 다른 스크립트 변수 참조하기 위한 코드 2줄
        ingame = GameObject.Find("Script").GetComponent<InGame>();
        changesuryong = GameObject.Find("Script").GetComponent<changeSuryong>();
        effectSM = GameObject.Find("Script").GetComponent<effectSoundManager>();

    }

    void Update()
    {
        showshopinfo();
        displaycat();
    }
    void showshopinfo()
    {
        pCrystalText.text = GetThousandCommaText(pCrystal) + "수정";
        pRandomText.text = GetThousandCommaText(pRandom) + "수정";
        pClickText.text = GetThousandCommaText(pClick) + "수정";
        pFeverText.text = GetThousandCommaText(pFever) + "수정";
        pCatsText.text = GetThousandCommaText(pCats) + "수정";
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }

    public void shopCrystal()   // 수정구 구매
    {
        if (ingame && changesuryong)    // 오류 방지
        {
            if (ingame.money >= pCrystal && changesuryong.ind <= 8 && !changesuryong.haveADrink)
            {
                ingame.money -= pCrystal;
                changesuryong.ind++;
                pCrystal *= 5;   // 가격 조정, 추후 수정 필요
                shopobj.SetActive(false);
                effectSM.PlaySound("LvUP");
            }
            else if (changesuryong.haveADrink)
            {
                alert.SetActive(true);
                alertmsg.text = "수룡이를 원상태로 돌려주어야 합니다.";
                effectSM.PlaySound("Alert");
            }
            else if (ingame.money<pCrystal)
            {
                alert.SetActive(true);
                alertmsg.text = "소지금이 부족합니다.";
                effectSM.PlaySound("Alert");
            }
            else
            {
                alert.SetActive(true);
                alertmsg.text = "아이템을 구매할 수 없습니다.";
                effectSM.PlaySound("Alert");
            }

        }
    }

    public void shopClick() // 클릭 구매
    {
        if (ingame)
        {
            if (ingame.money >= pClick)
            {
                ingame.money -= pClick;
                ingame.moneyIncreaseAmount *= 2;   // 추후 수정 필요
                pClick *= 2; // 가격조정 수정필요
                pFever = pClick;
                effectSM.PlaySound("Buy");
            }
            else
            {
                alert.SetActive(true);
                alertmsg.text = "소지금이 부족합니다.";
                effectSM.PlaySound("Alert");
            }
        }
    }

    public void shopRandom()    // 랜덤물약 구매
    {
        if (ingame && changesuryong)
        {
            rnum = Random.Range(0, 10); // 랜덤 난수 생성
            if (ingame.money >= pRandom && changesuryong.ind <= 8 && !changesuryong.haveADrink)
            {
                ingame.money -= pRandom;
                pRandom += 5; // 가격조정 수정필요

                if (rnum == 1)  // 1일 때만 업그레이드(10퍼센트 확률)
                {
                    changesuryong.haveADrink = false;
                    changesuryong.limit = 0;
                    changesuryong.ind++;
                    effectSM.PlaySound("LvUP");
                }
                else
                {
                    changesuryong.haveADrink = true;
                    changesuryong.limit = 0;
                    effectSM.PlaySound("Random");
                }
                shopobj.SetActive(false);
            }
            else if (changesuryong.haveADrink)
            {
                alert.SetActive(true);
                alertmsg.text = "수룡이를 원상태로 돌려주어야 합니다.";
                effectSM.PlaySound("Alert");
            }
            else if (ingame.money < pRandom)
            {
                alert.SetActive(true);
                alertmsg.text = "소지금이 부족합니다.";
                effectSM.PlaySound("Alert");
            }
            else
            {
                alert.SetActive(true);
                alertmsg.text = "아이템을 구매할 수 없습니다.";
                effectSM.PlaySound("Alert");
            }
        }
    }


    public void shopFever() // 피버 구매
    {
        
        if (ingame)
        {
            if (ingame.money >= pFever && !isFever)
            {
                ingame.money -= pFever;
                isFever = true;     // 현재 fever상태임 (피버 상태에서 또 아이템 구매하는 거 방지)
                tmp = ingame.moneyIncreaseAmount;
                ingame.moneyIncreaseAmount *= 3; //3배로!!
                shopobj.SetActive(false);
                fevertime.SetActive(true);
                

                 Invoke("endFever", 10f);     // 10초 시간 지연 후 endFever 실행.
                 
            }
            else if (ingame.money < pFever)
            {
                alert.SetActive(true);
                alertmsg.text = "소지금이 부족합니다.";
                effectSM.PlaySound("Alert");
            }
            else if (isFever)
            {
                alert.SetActive(true);
                alertmsg.text = "피버타임 중에는 구매할 수 없습니다.";
                effectSM.PlaySound("Alert");
            }
        }
    }

    private void endFever() {
        fevertime.SetActive(false);
        ingame.moneyIncreaseAmount = tmp; //다시 원래 증가량으로 되돌림.
        isFever = false;    // Fever상태 종료
    }


    public void shopCat()
    {
        if (ingame)
        {
            if (ingame.money >= pCats) //구매 가능할만큼 돈이 있는지 검사.
            {
                if (numOfCats > 0) //고양이는 3개까지만 구매 가능함! 처음 numOfCats값은 3.
                {
                    // 1. 고양이 표시
                    // cats[numOfCats - 1].SetActive(true); 
                    //numofCats를 인덱스로 활용.
                    // 3부터 시작해서 2, 1 이렇게 줄어드니까
                    // cats[2]가 제일 먼저 표시되고 그 다음 cats[1], 그 다음 cats[0] 순서

                    // 2. 소지금 자동 증가
                    ingame.autoIncreaseAmount += 10; 
                    //고양이 하나당 2씩 증가하도록.
                    //고양이 세 개 다 구매하면 프레임 당 6만큼 증가.


                    numOfCats--; //하나 구매했으니까 고양이 개수 감소시키기.
                    ingame.money -= pCats; //소지금 감소시키기

                    pCats += 10; //원래 가격이 5였으면 그 다음은 15. 그 다음은 25!
                }
                else
                {
                    //고양이 구매 다 해서 구매 불가능하다는 팝업창 띄우기
                    alert.SetActive(true);
                    alertmsg.text = "더이상 고양이를 키울 수 없습니다.";
                    effectSM.PlaySound("Alert");
                }
            }
            else
            {
                alert.SetActive(true);
                alertmsg.text = "소지금이 부족합니다.";
                effectSM.PlaySound("Alert");
            }
        }
    }
    void displaycat()
    {
        if (numOfCats<3 && numOfCats >= 0)
        {
            for (int i=3; i>numOfCats; i--)
            {
                cats[i-1].SetActive(true);
            }
        }
        if (numOfCats >= 3)
            for (int i = 0; i > 3; i++)
                cats[i].SetActive(false);
    }

}
