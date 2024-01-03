using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
	public SaveData(string _name, int _episode, string _date)
	{
		name = _name;
		episode = _episode;
		date = _date;
	}

	public string name; // ó���� �Է��ϴ� ĳ���� �̸�
	public int episode; // ����Ǵ� ���Ǽҵ�
	public string date; // ������ ��¥

}