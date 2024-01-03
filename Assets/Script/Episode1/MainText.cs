using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MainText : MonoBehaviour
{
    public GameObject Dialogue; // 텍스트 상자
    public Image Character; // 캐릭터(조승아)
    public GameObject SchoolBackGround; // 학교 배경화면
    public Text DialogueText; // 텍스트 상자안에있는 텍스트
    public Image NameTag; // 이름표
    public Text NameText; // 이름표안에 이름

    public GameObject NamePanel; // 이름정할때 나오는 판넬
    public GameObject NameSelectButton; // 이름 선택 확인 버튼
    public InputField NameInputfield; // 이름 입력하는 곳

    public int ClickTime; // 클릭횟수
    public bool doClick; // 클릭이 가능한가?
    private byte time = 0; // 사진이 밝아지는 시간

    //---------------------------------------------------
    [Serializable] // 직렬화(인스펙터 창에 보이게 하기 위함)
    public struct SelectionTextButton // 선택지 버튼, 텍스트
    {
        public Button Selection; // 버튼
        public Text SelectionText; // 버튼 텍스트
    }

    //--------------------------------------------------텍스트 1글자씩 출력하는 코드
    public string fullText; // 전체 텍스트
    private string currentText = ""; // 현재 출력되고 있는 텍스트
    public int Text_LengthCount; // 텍스트 길이
    public bool TextCoroutineIsRunning; // 텍스트코루틴이 실행 중인가?
    public GameObject TextendImage; // 텍스트 끝나면 뒤에 텍스트 끝에 애니메이션 넣음

    //----------------버튼 구조체 배열--------------
    public GameObject SelectionRoot; // 선택지 부모
    public SelectionTextButton[] selectionArray; // 구조체 배열 선언

    void Start()
    {
        StartFadeINOUT(); // 시작시 페이드 인 아웃 
        TextCoroutineIsRunning = false; // 코루틴 시작 안했으니까 False
        TextendImage.SetActive(false); // 텍스트 끝부분 이미지 끄기
        SelectionRoot.SetActive(false); // 처음 시작시 끄기

    }

    public void StartFadeINOUT()
    {
        doClick = true;
        Dialogue.SetActive(false); // 텍스트 상자 꺼짐
        NamePanel.SetActive(false); // 이름 정하는 판넬 꺼짐
        NameSelectButton.SetActive(false); // 이름 확인 버튼
        NameTag.color = new Color32(255, 255, 255, 0); // 이름표 투명도 0
        //Character.color = new Color32(255, 255, 255, 0); // 캐릭터 투명도 0
        DialogueText.color = new Color32(90, 35, 65, 0); // 메인택스트 투명도 0;
        NameText.color = new Color32(90, 35, 65, 0); // 이름택스트 투명도 0;
        NameText.text = "???"; // 이름표안의 이름
        StartCoroutine("DialogueSetting"); // 코루틴 시작
    }

    IEnumerator DialogueSetting() // 시작된 코루틴
    {
        Dialogue.SetActive(true); // 대화상자 켜짐
        while (true) // 무한 회로
        {
            time++; // 시간 값
            yield return new WaitForSeconds(0.0001f); // 0.0001초 기다림
            NameTag.color = new Color32(255, 255, 255, time); // 투명도 조절
            //Character.color = new Color32(255, 255, 255, time); // 투명도 조절
            DialogueText.color = new Color32(90, 35, 65, time); // 투명도 조절
            NameText.color = new Color32(90, 35, 65, time); // 투명도 조절
            if (time >= 255) // 시간 값이 255이고 투명도 값이 최대인 255가 되면 멈춤
            {
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doClick == true || Input.GetMouseButtonDown(0) && doClick == true) // 스페이스 클릭 시 클릭횟수 1 증가, 클릭할 수 있는 상황이면 클릭 타임 증가
        {
            if (TextCoroutineIsRunning == false) // 텍스트를 쓰는 코루틴이 실행 중인가?
            {
                TextendImage.SetActive(false);
                ClickTime++;
                Click();
            }
            else
            {
                DialogueText.text = fullText; //쓰는 코루틴이 실행중이면 텍스트에다가 모든 텍스트 넣음
                Text_LengthCount = fullText.Length; // 텍스트 카운트에 텍스트 전체 길이를 넣음
                TextendImage.SetActive(true);
            }
        }
    }

    void Click() // 스페이스바 누를때 나오는 텍스트들 (대사)
    {
        if (ClickTime == 1)
        {
            NameText.text = "나";
            fullText = "(아... 드디어 왔다..)";
            StartCoroutine(ShowText());
        }

        if(ClickTime == 2)
        {
            fullText = "(여기가 시난 마이스터 고등학교 인가?)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 3)
        {
            SchoolBackGround.SetActive(false);
            fullText = "(여기 내 반이.... 1-x반..?)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 4)
        {
            fullText = "(벌써 여러 친구들이 친해진 채로 있었다.)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            fullText = "(남은 자리로 보이는 곳으로 가서 자리에 앉아 짐을 풀고 있던 그 때 였다..)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 6)
        {
            NameText.text = "???";
            Character.color = new Color32(255,255,255,255);
            fullText = "안녕! 아 잠깐 이름이 뭐라고 했지?";
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
            fullText = SaveSystem.Load("Save" + Title.SceneNum).name + " 이구나! 안녕! " + SaveSystem.Load("Save" + Title.SceneNum).name + "!" + " 내 이름은 \"조승아\"라고 해!";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 9)
        {
            fullText = "반장인 내가 찾아온 이유는 요번주까지 동아리 가입 주간인데 신청을 하지 못하면 선생님들이 운영하는 동아리들만 남아서 너한테 말해줘야 될 것 같아서 왔어!";
            StartCoroutine(ShowText());
        }

        if(ClickTime == 10)
        {
            fullText = "( 어떡하지 아무 동아리도 모르는데.... )";
            StartCoroutine(ShowText());
        }

        if(ClickTime == 10)
        {
            fullText = " (물어봐야겠지? )";
            StartCoroutine(ShowText());
        }
        
        if(ClickTime == 11)
        {
            
        }
    }

    public void Onvalue()
    {
        NameSelectButton.SetActive(true); // 텍스트 박스 안에 이름이 입력될 시 확인 버튼 켜짐
    }

    public void SaveButton()
    {
        doClick = true; // 클릭 가능
        NamePanel.SetActive(false); // 이름 쓰는 판넬 삭제

        SaveData ned = new SaveData(NameInputfield.text, 0, DateTime.Now.ToString("yyyy.MM.dd HH:mm")); // 버튼을 눌렀을때 이름 저장
        SaveSystem.Save(ned, "Save" + Title.SceneNum); // 이름 저장
    }
  
    public void ShowName()
    {
        NameText.text = "조승아"; // 이름을 바꿈
    }

    IEnumerator ShowText() //텍스트 글자 한 글자 씩 출력
    {
        TextCoroutineIsRunning = true; // 코루틴이 실행 중일때
        for (Text_LengthCount = 0; Text_LengthCount <= fullText.Length; Text_LengthCount++) 
        {
            currentText = fullText.Substring(0, Text_LengthCount);
            DialogueText.text = currentText;
            yield return new WaitForSeconds(0.03f);
        }
        yield return
        TextCoroutineIsRunning = false;// 코루틴이 끝났을 때
        TextendImage.SetActive(true); // 텍스트 창 뒤에 뜨는거
    }

    //SelectionButton 버튼 처리
    public void SelectionButton1()
    {
        doClick = true; // 다시 클릭 가능하게 바꿈
        SelectionRoot.SetActive(false); // 선택창 꺼짐
    }

    public void SelectionButton2()
    {
        doClick = true; // 다시 클릭 가능하게 바꿈
        SelectionRoot.SetActive(false); // 선택창 꺼짐
    }
}
