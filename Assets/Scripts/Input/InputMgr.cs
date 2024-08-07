using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : BaseManager<InputMgr>
{
    private bool isStart = false;

    public InputMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
    }

    public void StartOrEndCheck(bool isOpen)
    {
        isStart = isOpen;

    }

    private void CheckKeyCode(KeyCode keyCode)
    {

        if (Input.GetKeyDown(keyCode))
            EventCenter.GetInstance().EventTrigger("Ä³¼ü°´ÏÂ", keyCode);
        if (Input.GetKeyUp(keyCode))
            EventCenter.GetInstance().EventTrigger("Ä³¼üÌ§Æð", keyCode);
    }

    private void MyUpdate()
    {
        if (!isStart)
            return;

        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);
       
    }

}
