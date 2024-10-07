using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class problum : MonoBehaviour
{
    public GameObject problom;
    public string cham;
    public Text can;
    public bool open,close;
    private Coroutine closeCoroutine; // 코루틴을 저장할 변수

    public void button1() { can.text += "1"; }
    public void button2() { can.text += "2"; }
    public void button3() { can.text += "3"; }
    public void button4() { can.text += "4"; }
    public void button5() { can.text += "5"; }
    public void button6() { can.text += "6"; }
    public void button7() { can.text += "7"; }
    public void button8() { can.text += "8"; }
    public void button9() { can.text += "9"; }
    public void button0() { can.text += "0"; }

    public void back() { can.text = ""; }

    public void enter()
    {
        if (can.text == cham)
        {
            open = true;
            problom.SetActive(false);
        }
        else
        {
            can.text = "";
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            close = true;
            problom.SetActive(false);
            
        }
    }

}
