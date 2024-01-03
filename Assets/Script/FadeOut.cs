using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public GameObject Fadeout;//페이드 아웃 판넬

    private byte BrightTime = 255; //페이드 아웃 때 사용되는 시간
    // Start is called before the first frame update
    void Start()
    {
        Fadeout.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Fadeout.SetActive(true);
        //BrightTime = 255;
        StartCoroutine("FadeOutDark");
    }
    IEnumerator FadeOutDark()
    {
        while (true)
        {
            BrightTime--;
            yield return new WaitForSeconds(0.01f);
            Fadeout.GetComponent<Image>().color = new Color32(0, 0, 0, BrightTime);
            if (BrightTime <= 0)
            {
                break;
            }
        }
        Fadeout.SetActive(false);
    }
}
