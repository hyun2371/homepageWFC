using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;




public class sortGame : MonoBehaviour
{
    System.Random rand;
    int[] randArr = new int[5];
    int[] ansArr = new int[5];
    public Text explain;
    public Text[] randText = new Text[5];
    //public Text[] ansText = new Text[5];
    public List<int> userData;
    int count = 0;
    //유저가 해당 글자 클릭하면 user배열에 담기도록 한다.
    public Text alert;
    public Text userText;


    //다른 씬의 변수 어떻게 연결할지 생각!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    // Start is called before the first frame update
    void Start()
    {

        // 텍스트 출력. 설명 출력.
        explain.text = "아래 숫자들을 작은 숫자부터\n순서대로 터치하세요!";
        userText.text = "입력 : ";
        alert.text = "";

        makeRand();
        sortRand();
        showGame();
            
    }

    public void makeRand()
    {
        //랜덤 난수 넣기
        rand = new System.Random();
        
        
        // 랜덤으로 인덱스 생성해서(0~99) tmp값을 가져옴!
        for(int i = 0; i < 5; i++)
        {
            randArr[i] = noDup();
            //0~99사이의 중복 없는 수가 들어가도록!
            
        }
    }

    private int noDup()
    {
        rand = new System.Random();
        int tmp = rand.Next() % 100;
        if (randArr.Contains(tmp))
        {
            tmp=noDup();
        }
        return tmp;
       
    }


    //랜덤 생성된 숫자 담은 후 정렬!
    public void sortRand()
    {
        for(int i = 0; i < 5; i++)
        {
            ansArr[i] = randArr[i];
        }
        Array.Sort(ansArr);
    }

    //각 버튼에 텍스트를 담는다
    public void showGame()
    {
        
        //텍스트 담고
        for(int i = 0; i < 5; i++)
        {
            randText[i].text = randArr[i].ToString();
        }
    }

    //유저가 숫자 클릭시 배열에 담기도록 
    public void inputData()
    {
        if (count < 5)
        {
            count++;
            GameObject clickObject = EventSystem.current.currentSelectedGameObject;

            switch (Convert.ToInt32(clickObject.name))
            {
                case 1:
                    userData.Add(randArr[0]);
                    userText.text = userText.text + " "+randArr[0];
                    break;
                case 2:
                    userData.Add(randArr[1]);
                    userText.text = userText.text + " " + randArr[1];
                    break;
                case 3:
                    userData.Add(randArr[2]);
                    userText.text = userText.text + " " + randArr[2];
                    break;
                case 4:
                    userData.Add(randArr[3]);
                    userText.text = userText.text + " " + randArr[3];
                    break;
                case 5:
                    userData.Add(randArr[4]);
                    userText.text = userText.text + " " + randArr[4];
                    break;
            }

            Invoke("checkAns", 1.6f);

        }
    }

    //정답과 비교. 맞으면 정답 메세지 출력 후 종료. 틀리면 틀렸습니다 메세지 출력
    public void checkAns()
    {
        bool checkBreak = false;
        if (count == 5)
        {
            for(int i = 0; i < 5; i++)
            {
                if (userData[i] != ansArr[i])
                {
                    alert.text = "틀렸습니다.\n다시 생각해 보세요!";

                    for (int j = 0; j < 10000; j++) ; //시간을 둠

                    count = 0;
                    userData.Clear();
                    userText.text = "입력 : ";
                    checkBreak = true;
                    break;
                }
            }
            if (!checkBreak)
            {
                alert.text = "성공했습니다!\n100 수정을 획득하였습니다.";
                

                Invoke("changeScene", 1f);
            }
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene("1main");
    }
    

        // Update is called once per frame
    void Update()
    {

    }
}

