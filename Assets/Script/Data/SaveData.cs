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

	public string name; // 처음에 입력하는 캐릭터 이름
	public int episode; // 진행되는 에피소드
	public string date; // 마지막 날짜

}