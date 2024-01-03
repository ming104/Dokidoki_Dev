using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public GameObject Fadeout;//���̵� �ƿ� �ǳ�

    private byte BrightTime = 255; //���̵� �ƿ� �� ���Ǵ� �ð�
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
