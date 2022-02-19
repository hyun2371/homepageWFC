using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changeSuryong : MonoBehaviour
{
    //수룡이 이미지 11개 (마지막 이미지가 우람한 수룡)
    public GameObject[] states = new GameObject[11];

    public GameObject limitbutton;

    public int ind = 0;
    public bool haveADrink = false;
    public int limit = 0;

    void Update()
    {
        // 수룡이 업데이트
        for (int i = 0; i < 11; i++)
        {
            if (i == ind)
                states[i].SetActive(true);
            else
                states[i].SetActive(false);
        }

        if (haveADrink) // haveADrink 수룡이일 때
        {
            limitbutton.SetActive(true);
            //정상적인 ind범위는 0~9까지. 10은 이상한 물약 먹었을 때.

            if (limit < 15)
            {
                for (int i = 0; i < 10; i++)
                    states[i].SetActive(false);
                states[10].SetActive(true);
            }
            else
            {
                haveADrink = false;
                limit = 0;
            }
        }
        else
            limitbutton.SetActive(false);

    }
    public void touchlimit()
    {
        limit++;
    }
}
