using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Title : MonoBehaviour
{

    public GameObject GameLogo; // �αٵα� ���ߺ� ������
    public GameObject Saving_File_Select; // ���� Ŭ��
    public GameObject ClickText; // ���� �����ҷ��� Ŭ���ϼ�
    private bool FirstClick; // ó��Ŭ�� ����


    public GameObject Panel;
    public static int SceneNum;
    private byte time;

    // Ÿ��Ʋ�� �ִ� ��ư ����ü �迭
    [Header ("����ü �迭")]
    public TitleButton[] SaveText;

    [Serializable]
    public struct TitleButton
    {
        public Text Name; 
        public Text Date;
        public Text Episode;
       
    }
    // ����ü ��

    void Awake()
    {
        // ��� ������ ���� ��� ����
        if (File.Exists(Application.persistentDataPath + "/saves/" + "Save1.json") == false)
        {
            SaveData Save1 = new SaveData("", 0, ""); // �ʱ�ȭ
            SaveSystem.Save(Save1, "Save1"); // ����
        }

        if (File.Exists(Application.persistentDataPath + "/saves/" + "Save2.json") == false)
        {
            SaveData Save2 = new SaveData("", 0, ""); // �ʱ�ȭ
            SaveSystem.Save(Save2, "Save2"); // ����
        }

        if (File.Exists(Application.persistentDataPath + "/saves/" + "Save3.json") == false)
        {
            SaveData Save3 = new SaveData("", 0, ""); // �ʱ�ȭ
            SaveSystem.Save(Save3, "Save3"); // ����
        }
        // Ÿ��Ʋ ����
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

        //����� �ؽ�Ʈ---------------------------------------------------------

        //1��° ��ư
        if (SaveSystem.Load("Save1").date != "")
        {
            SaveText[0].Name.text = SaveSystem.Load("Save1").name;
            SaveText[0].Date.text = SaveSystem.Load("Save1").date;
            SaveText[0].Episode.text = "Episode " + SaveSystem.Load("Save1").episode.ToString();
        }
        else
        {
            SaveText[0].Name.text = "���� �����ϱ�";
            SaveText[0].Date.text = "";
            SaveText[0].Episode.text = "";
        }

        //2��° ��ư
        if (SaveSystem.Load("Save2").date != "")
        {
            SaveText[1].Name.text = SaveSystem.Load("Save2").name;
            SaveText[1].Date.text = SaveSystem.Load("Save2").date;
            SaveText[1].Episode.text = "Episode " + SaveSystem.Load("Save2").episode.ToString();
        }
        else
        {
            SaveText[1].Name.text = "���� �����ϱ�";
            SaveText[1].Date.text = "";
            SaveText[1].Episode.text = "";
        }

        //3��° ��ư
        if (SaveSystem.Load("Save3").date != "")
        {
            SaveText[2].Name.text = SaveSystem.Load("Save3").name;
            SaveText[2].Date.text = SaveSystem.Load("Save3").date;
            SaveText[2].Episode.text = "Episode " + SaveSystem.Load("Save3").episode.ToString();
        }
        else
        {
            SaveText[2].Name.text = "���� �����ϱ�";
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

    IEnumerator ColorChange() // ���̵� ��?
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
