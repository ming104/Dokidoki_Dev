using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManage : MonoBehaviour
{
    public AudioSource HoverSound;
    public AudioSource ClickStart;
    public AudioSource ClickEnd;

    Texture2D hand;
    Texture2D original;

    void Start()
    {
        hand = Resources.Load<Texture2D>("hand");
        original = Resources.Load<Texture2D>("original");
    }

    public void OnMouseOver()
    {
        Cursor.SetCursor(hand, new Vector2(hand.width / 3, 0), CursorMode.Auto);
        HoverSound.Play();
    }

    public void OnMouseDown()
    {
        Cursor.SetCursor(hand, new Vector2(hand.width / 3, 0), CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(original, new Vector2(0, 0), CursorMode.Auto);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ClickStart.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ClickEnd.Play();
        }
    }
}
