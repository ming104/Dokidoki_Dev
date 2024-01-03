using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveAndLoadController : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveData Save1 = new SaveData("조근호", 5, DateTime.Now.ToString("yyyy.MM.dd HH:mm")); // 불러오기 예시

            SaveSystem.Save(Save1, "Save1"); // Save(저장할 데이터, "저장될 파일 이름");
        }
    }
}
