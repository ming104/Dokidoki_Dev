using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MainText : MonoBehaviour
{
    public GameObject Dialogue; // �ؽ�Ʈ ����
    public Image Character; // ĳ����(���¾�)
    public GameObject SchoolBackGround; // �б� ���ȭ��
    public Text DialogueText; // �ؽ�Ʈ ���ھȿ��ִ� �ؽ�Ʈ
    public Image NameTag; // �̸�ǥ
    public Text NameText; // �̸�ǥ�ȿ� �̸�

    public GameObject NamePanel; // �̸����Ҷ� ������ �ǳ�
    public GameObject NameSelectButton; // �̸� ���� Ȯ�� ��ư
    public InputField NameInputfield; // �̸� �Է��ϴ� ��

    public int ClickTime; // Ŭ��Ƚ��
    public bool doClick; // Ŭ���� �����Ѱ�?
    private byte time = 0; // ������ ������� �ð�

    //---------------------------------------------------
    [Serializable] // ����ȭ(�ν����� â�� ���̰� �ϱ� ����)
    public struct SelectionTextButton // ������ ��ư, �ؽ�Ʈ
    {
        public Button Selection; // ��ư
        public Text SelectionText; // ��ư �ؽ�Ʈ
    }

    //--------------------------------------------------�ؽ�Ʈ 1���ھ� ����ϴ� �ڵ�
    public string fullText; // ��ü �ؽ�Ʈ
    private string currentText = ""; // ���� ��µǰ� �ִ� �ؽ�Ʈ
    public int Text_LengthCount; // �ؽ�Ʈ ����
    public bool TextCoroutineIsRunning; // �ؽ�Ʈ�ڷ�ƾ�� ���� ���ΰ�?
    public GameObject TextendImage; // �ؽ�Ʈ ������ �ڿ� �ؽ�Ʈ ���� �ִϸ��̼� ����

    //----------------��ư ����ü �迭--------------
    public GameObject SelectionRoot; // ������ �θ�
    public SelectionTextButton[] selectionArray; // ����ü �迭 ����

    void Start()
    {
        StartFadeINOUT(); // ���۽� ���̵� �� �ƿ� 
        TextCoroutineIsRunning = false; // �ڷ�ƾ ���� �������ϱ� False
        TextendImage.SetActive(false); // �ؽ�Ʈ ���κ� �̹��� ����
        SelectionRoot.SetActive(false); // ó�� ���۽� ����

    }

    public void StartFadeINOUT()
    {
        doClick = true;
        Dialogue.SetActive(false); // �ؽ�Ʈ ���� ����
        NamePanel.SetActive(false); // �̸� ���ϴ� �ǳ� ����
        NameSelectButton.SetActive(false); // �̸� Ȯ�� ��ư
        NameTag.color = new Color32(255, 255, 255, 0); // �̸�ǥ ���� 0
        //Character.color = new Color32(255, 255, 255, 0); // ĳ���� ���� 0
        DialogueText.color = new Color32(90, 35, 65, 0); // �����ý�Ʈ ���� 0;
        NameText.color = new Color32(90, 35, 65, 0); // �̸��ý�Ʈ ���� 0;
        NameText.text = "???"; // �̸�ǥ���� �̸�
        StartCoroutine("DialogueSetting"); // �ڷ�ƾ ����
    }

    IEnumerator DialogueSetting() // ���۵� �ڷ�ƾ
    {
        Dialogue.SetActive(true); // ��ȭ���� ����
        while (true) // ���� ȸ��
        {
            time++; // �ð� ��
            yield return new WaitForSeconds(0.0001f); // 0.0001�� ��ٸ�
            NameTag.color = new Color32(255, 255, 255, time); // ���� ����
            //Character.color = new Color32(255, 255, 255, time); // ���� ����
            DialogueText.color = new Color32(90, 35, 65, time); // ���� ����
            NameText.color = new Color32(90, 35, 65, time); // ���� ����
            if (time >= 255) // �ð� ���� 255�̰� ���� ���� �ִ��� 255�� �Ǹ� ����
            {
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doClick == true || Input.GetMouseButtonDown(0) && doClick == true) // �����̽� Ŭ�� �� Ŭ��Ƚ�� 1 ����, Ŭ���� �� �ִ� ��Ȳ�̸� Ŭ�� Ÿ�� ����
        {
            if (TextCoroutineIsRunning == false) // �ؽ�Ʈ�� ���� �ڷ�ƾ�� ���� ���ΰ�?
            {
                TextendImage.SetActive(false);
                ClickTime++;
                Click();
            }
            else
            {
                DialogueText.text = fullText; //���� �ڷ�ƾ�� �������̸� �ؽ�Ʈ���ٰ� ��� �ؽ�Ʈ ����
                Text_LengthCount = fullText.Length; // �ؽ�Ʈ ī��Ʈ�� �ؽ�Ʈ ��ü ���̸� ����
                TextendImage.SetActive(true);
            }
        }
    }

    void Click() // �����̽��� ������ ������ �ؽ�Ʈ�� (���)
    {
        if (ClickTime == 1)
        {
            NameText.text = "��";
            fullText = "(��... ���� �Դ�..)";
            StartCoroutine(ShowText());
        }

        if(ClickTime == 2)
        {
            fullText = "(���Ⱑ �ó� ���̽��� ����б� �ΰ�?)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 3)
        {
            SchoolBackGround.SetActive(false);
            fullText = "(���� �� ����.... 1-x��..?)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 4)
        {
            fullText = "(���� ���� ģ������ ģ���� ä�� �־���.)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            fullText = "(���� �ڸ��� ���̴� ������ ���� �ڸ��� �ɾ� ���� Ǯ�� �ִ� �� �� ����..)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 6)
        {
            NameText.text = "???";
            Character.color = new Color32(255,255,255,255);
            fullText = "�ȳ�! �� ��� �̸��� ����� ����?";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            NamePanel.SetActive(true);
            doClick = false;
        }

        if (ClickTime == 8)
        {
            Invoke("ShowName", 0.5f);
            fullText = SaveSystem.Load("Save" + Title.SceneNum).name + " �̱���! �ȳ�! " + SaveSystem.Load("Save" + Title.SceneNum).name + "!" + " �� �̸��� \"���¾�\"��� ��!";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 9)
        {
            fullText = "������ ���� ã�ƿ� ������ ����ֱ��� ���Ƹ� ���� �ְ��ε� ��û�� ���� ���ϸ� �����Ե��� ��ϴ� ���Ƹ��鸸 ���Ƽ� ������ ������� �� �� ���Ƽ� �Ծ�!";
            StartCoroutine(ShowText());
        }

        if(ClickTime == 10)
        {
            fullText = "( ����� �ƹ� ���Ƹ��� �𸣴µ�.... )";
            StartCoroutine(ShowText());
        }

        if(ClickTime == 10)
        {
            fullText = " (������߰���? )";
            StartCoroutine(ShowText());
        }
        
        if(ClickTime == 11)
        {
            
        }
    }

    public void Onvalue()
    {
        NameSelectButton.SetActive(true); // �ؽ�Ʈ �ڽ� �ȿ� �̸��� �Էµ� �� Ȯ�� ��ư ����
    }

    public void SaveButton()
    {
        doClick = true; // Ŭ�� ����
        NamePanel.SetActive(false); // �̸� ���� �ǳ� ����

        SaveData ned = new SaveData(NameInputfield.text, 0, DateTime.Now.ToString("yyyy.MM.dd HH:mm")); // ��ư�� �������� �̸� ����
        SaveSystem.Save(ned, "Save" + Title.SceneNum); // �̸� ����
    }
  
    public void ShowName()
    {
        NameText.text = "���¾�"; // �̸��� �ٲ�
    }

    IEnumerator ShowText() //�ؽ�Ʈ ���� �� ���� �� ���
    {
        TextCoroutineIsRunning = true; // �ڷ�ƾ�� ���� ���϶�
        for (Text_LengthCount = 0; Text_LengthCount <= fullText.Length; Text_LengthCount++) 
        {
            currentText = fullText.Substring(0, Text_LengthCount);
            DialogueText.text = currentText;
            yield return new WaitForSeconds(0.03f);
        }
        yield return
        TextCoroutineIsRunning = false;// �ڷ�ƾ�� ������ ��
        TextendImage.SetActive(true); // �ؽ�Ʈ â �ڿ� �ߴ°�
    }

    //SelectionButton ��ư ó��
    public void SelectionButton1()
    {
        doClick = true; // �ٽ� Ŭ�� �����ϰ� �ٲ�
        SelectionRoot.SetActive(false); // ����â ����
    }

    public void SelectionButton2()
    {
        doClick = true; // �ٽ� Ŭ�� �����ϰ� �ٲ�
        SelectionRoot.SetActive(false); // ����â ����
    }
}
