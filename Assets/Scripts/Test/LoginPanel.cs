using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        FindChildren<Button>();
        GetControl<Button>("btnStart").onClick.AddListener(ClickStart);
        GetControl<Button>("btnQuit").onClick.AddListener(ClickQuit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStart()
    {
        Debug.Log("Start");
    }

    public void ClickQuit()
    {
        Debug.Log("Quit");
    }

    public void InitInfo()
    {
        Debug.Log("��ʼ����Ϣ");
    }

}
