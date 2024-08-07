using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", E_UI_Layer.Top,ShowPanelOver);
    }
    // Start is called before the first frame update
    void Start()
    {
        //EventCenter.GetInstance().AddEventListener("Dead", (object info) =>
        //{
        //    Debug.Log("获得奖励" + (info as DelayPush).name1 );
        //});

        
        //UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", E_UI_Layer.Top, ShowPanelOver);
    }

    private void ShowPanelOver(LoginPanel panel)
    {
        Debug.Log("初始化信息");
        Invoke("DelayHide", 3);
    }

    private void DelayHide()
    {
        UIManager.GetInstance().HidePanel("LoginPanel");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    PoolMgr.GetInstance().GetObj("Test/Cube", (o) =>
        //    {
        //        o.transform.localScale = Vector3.one * 2;
        //    });
        //    ResMgr.GetInstance().Load<GameObject>("Test/Cube");

        //    MusicMgr.GetInstance().PlayBkMusic("BGM_HuangJinWu");

        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    PoolMgr.GetInstance().GetObj("Test/Sphere");
        //    ResMgr.GetInstance().LoadAsync<GameObject>("Test/Cube", DoSomthing);
        //    MusicMgr.GetInstance().ChangeBkValue(0.5f);
        //}
    }

    private void DoSomthing(GameObject obj)
    {
        obj.transform.localScale = Vector3.one * 2;
    }

}
