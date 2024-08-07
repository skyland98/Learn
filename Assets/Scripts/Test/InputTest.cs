using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        InputMgr.GetInstance().StartOrEndCheck(true);

        EventCenter.GetInstance().AddEventListener("某键按下", CheckInputDown);
        EventCenter.GetInstance().AddEventListener("某键抬起", CheckInputUp);
    }

    private void CheckInputDown(object key)
    {
        KeyCode code = (KeyCode)key;
        switch(code)
        {
            case KeyCode.W:
                Debug.Log("前进");
                MusicMgr.GetInstance().PlaySound("KeQing_SmallSkillSound1", false);
                break;
            case KeyCode.A:
                Debug.Log("左转");
                MusicMgr.GetInstance().PlaySound("BGM_XianYiYouXia", false, (s) =>
                {
                    m_AudioSource = s;
                });
                break;
            case KeyCode.S:
                Debug.Log("后退");
                MusicMgr.GetInstance().ChangeSoundValue(0.5f);
                break;
            case KeyCode.D:
                Debug.Log("右转");
                MusicMgr.GetInstance().StopSound(m_AudioSource);
                m_AudioSource=null;
                break;
        }
    }

    private void CheckInputUp(object key)
    {
        KeyCode code = (KeyCode)key;
        switch (code)
        {
            case KeyCode.W:
                Debug.Log("停止前进");
                break;
            case KeyCode.A:
                Debug.Log("停止左转");
                break;
            case KeyCode.S:
                Debug.Log("停止后退");
                break;
            case KeyCode.D:
                Debug.Log("停止右转");
                break;
        }
    }

}
