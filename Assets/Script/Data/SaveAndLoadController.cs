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
            SaveData Save1 = new SaveData("����ȣ", 5, DateTime.Now.ToString("yyyy.MM.dd HH:mm")); // �ҷ����� ����

            SaveSystem.Save(Save1, "Save1"); // Save(������ ������, "����� ���� �̸�");
        }
    }
}
