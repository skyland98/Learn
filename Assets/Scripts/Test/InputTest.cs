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

        EventCenter.GetInstance().AddEventListener("ĳ������", CheckInputDown);
        EventCenter.GetInstance().AddEventListener("ĳ��̧��", CheckInputUp);
    }

    private void CheckInputDown(object key)
    {
        KeyCode code = (KeyCode)key;
        switch(code)
        {
            case KeyCode.W:
                Debug.Log("ǰ��");
                MusicMgr.GetInstance().PlaySound("KeQing_SmallSkillSound1", false);
                break;
            case KeyCode.A:
                Debug.Log("��ת");
                MusicMgr.GetInstance().PlaySound("BGM_XianYiYouXia", false, (s) =>
                {
                    m_AudioSource = s;
                });
                break;
            case KeyCode.S:
                Debug.Log("����");
                MusicMgr.GetInstance().ChangeSoundValue(0.5f);
                break;
            case KeyCode.D:
                Debug.Log("��ת");
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
                Debug.Log("ֹͣǰ��");
                break;
            case KeyCode.A:
                Debug.Log("ֹͣ��ת");
                break;
            case KeyCode.S:
                Debug.Log("ֹͣ����");
                break;
            case KeyCode.D:
                Debug.Log("ֹͣ��ת");
                break;
        }
    }

}
