using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm_Manager : MonoBehaviour
{
    public GameObject BackgroundMusic;

    void Awake()
    {
        
         DontDestroyOnLoad(BackgroundMusic);
    }
}
