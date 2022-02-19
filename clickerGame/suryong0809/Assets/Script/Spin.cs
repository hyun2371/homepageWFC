using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    float speed = 0;
    private int finalAngle;
    [SerializeField]
    public Text winText;
    bool isPressed = false;
    long reward;
    int locked = 1;
    InGame ingame;

    void Start()
    {
        ingame = GameObject.Find("Script").GetComponent<InGame>();
    }
    void Update()
    {
        playspin();
        showReward();
    }
    void playspin()
    {
        if (isPressed) //버튼 눌렀음
        {
            Debug.Log("플레이스핀");
            this.speed = Random.Range(30, 70); //해당 문장 없이 룰렛이 안돌아감
            locked--;
        }
        transform.Rotate(0, 0, this.speed);
        this.speed *= 0.97f;

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        switch (finalAngle)
        {
            case 0:
                reward = 1000;
                break;
            case 60:
                reward = 2000;
                break;
            case 120:
                reward = 3000;
                break;
            case 180:
                reward = 4000;
                break;
            case 240:
                reward = 5000;
                break;
            case 300:
                reward = 6000;
                break;
        }
        isPressed = false;
        //Debug.Log(speed); 속도는 -E까지 거의 무한대로 감소
        if (this.speed <= 0.2 && locked == 0) //속도-룰렛이 어느정도 멈췄을때+ locked 변수로 조절(한 번 클릭에 돈 변화 한번이도록)
        {
            if (ingame)
            {
                for (int i = 0; i <= 2000; i++) ; //일정시간 대기
                ingame.money += reward;
                locked--;
            }

        }
    }
    void showReward()
    {
        winText.text = "You Win " + reward / 1000 + "K";
        if (ingame.money < 3000)
            winText.text = "소지금 부족";
    }
    public void ButtonPress() //start버튼 누를 시 호출
    {
        if (ingame)
        {
            Debug.Log("버튼누름");
            isPressed = true;

            if (ingame.money < 3000)
            {
                isPressed = false;
            }

            else
            {
                ingame.money -= 3000;
            }
            locked = 1; //다시 돈 제어 가능(버튼 한번 클릭당 한번의 돈 제어)
        }
    }
}
