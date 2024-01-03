using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charcter
{
    public string Name;
    public int Like;
    public int DisLike;
}

public class TalkList : MonoBehaviour
{
    private Charcter charcter;

    private void Start()
    {
        charcter = new Charcter();
    }
}