using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Title : MonoBehaviour
{

    public GameObject GameLogo; // 두근두근 개발부 아이콘
    public GameObject Saving_File_Select; // 저장 클릭
    public GameObject ClickText; // 게임 시작할려면 클릭하셈
    private bool FirstClick; // 처음클릭 여부


    public GameObject Panel;
    public static int SceneNum;
    private byte time;

    // 타이틀에 있는 버튼 구조체 배열
    [Header ("구조체 배열")]
    public TitleButton[] SaveText;

    [Serializable]
    public struct TitleButton
    {
        public Text Name; 
        public Text Date;
        public Text Episode;
       
    }
    // 구조체 끝

    void Awake()
    {
        // 모두 파일이 없는 경우 만듦
        if (File.Exists(Application.persistentDataPath + "/saves/" + "Save1.json") == false)
        {
            SaveData Save1 = new SaveData("", 0, ""); // 초기화
            SaveSystem.Save(Save1, "Save1"); // 생성
        }

        if (File.Exists(Application.persistentDataPath + "/saves/" + "Save2.json") == false)
        {
            SaveData Save2 = new SaveData("", 0, ""); // 초기화
            SaveSystem.Save(Save2, "Save2"); // 생성
        }

        if (File.Exists(Application.persistentDataPath + "/saves/" + "Save3.json") == false)
        {
            SaveData Save3 = new SaveData("", 0, ""); // 초기화
            SaveSystem.Save(Save3, "Save3"); // 생성
        }
        // 타이틀 셋팅
        Saving_File_Select.SetActive(false);
    }

    void Start()
    {
        Panel.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        Panel.SetActive(false);
        time = 0;
        Saver();
        FirstClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && FirstClick == false)
        {
            Saving_File_Select.SetActive(true);
            Saving_File_Select.GetComponent<Animation>().Play();
            GameLogo.GetComponent<Animation>().Play();
            ClickText.SetActive(false);
            FirstClick = true;
        }
    }

    public void Saver()
    {

        //저장된 텍스트---------------------------------------------------------

        //1번째 버튼
        if (SaveSystem.Load("Save1").date != "")
        {
            SaveText[0].Name.text = SaveSystem.Load("Save1").name;
            SaveText[0].Date.text = SaveSystem.Load("Save1").date;
            SaveText[0].Episode.text = "Episode " + SaveSystem.Load("Save1").episode.ToString();
        }
        else
        {
            SaveText[0].Name.text = "새로 시작하기";
            SaveText[0].Date.text = "";
            SaveText[0].Episode.text = "";
        }

        //2번째 버튼
        if (SaveSystem.Load("Save2").date != "")
        {
            SaveText[1].Name.text = SaveSystem.Load("Save2").name;
            SaveText[1].Date.text = SaveSystem.Load("Save2").date;
            SaveText[1].Episode.text = "Episode " + SaveSystem.Load("Save2").episode.ToString();
        }
        else
        {
            SaveText[1].Name.text = "새로 시작하기";
            SaveText[1].Date.text = "";
            SaveText[1].Episode.text = "";
        }

        //3번째 버튼
        if (SaveSystem.Load("Save3").date != "")
        {
            SaveText[2].Name.text = SaveSystem.Load("Save3").name;
            SaveText[2].Date.text = SaveSystem.Load("Save3").date;
            SaveText[2].Episode.text = "Episode " + SaveSystem.Load("Save3").episode.ToString();
        }
        else
        {
            SaveText[2].Name.text = "새로 시작하기";
            SaveText[2].Date.text = "";
            SaveText[2].Episode.text = "";
        }
    }

    public void ButtonClick1()
    {
        Panel.SetActive(true);
        StartCoroutine("ColorChange");
        SceneNum = 1;
    }
    public void ButtonClick2()
    {
        Panel.SetActive(true);
        StartCoroutine("ColorChange");
        SceneNum = 2;
    }

    public void ButtonClick3()
    {
        Panel.SetActive(true);
        StartCoroutine("ColorChange");
        SceneNum = 3;
    }

    IEnumerator ColorChange() // 페이드 인?
    {
        while(true)
        {
            time++;
            yield return new WaitForSeconds(0.001f);
            Panel.GetComponent<Image>().color = new Color32(0, 0, 0, time);
            if (time >= 255)
            {
                break;
            }
        }
        SceneManager.LoadScene("Episode"+SaveSystem.Load("Save"+ SceneNum).episode);
    }
}
