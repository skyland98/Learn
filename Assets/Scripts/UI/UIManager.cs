using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System
}

/// <summary>
/// UI管理器
/// 1.管理所有显示的面板
/// 2.提供给外部 显示和隐藏的接口
/// </summary>
public class UIManager : BaseManager<UIManager>
{
    public Dictionary<string,BasePanel> panelDic = new Dictionary<string,BasePanel>();

    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    public UIManager()
    {
        GameObject obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        Transform canvas = obj.transform;
        GameObject.DontDestroyOnLoad(obj);

        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }

    public void ShowPanel<T>(string panelName, E_UI_Layer layer =E_UI_Layer.Mid,UnityAction<T> callback = null) where T : BasePanel
    {
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            if(callback != null)
            {
                callback(panelDic[panelName] as T);
            }
        }


            ResMgr.GetInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
        {
            Transform father = bot;
            switch (layer)
            {            
                case E_UI_Layer.Mid:
                    father = mid;
                    break; 
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
            }

            obj.transform.SetParent(father);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;

            T panel = obj.GetComponent<T>();
            
            if (callback != null)
            {
                callback(panel);
            }

            panelDic.Add(panelName, panel);
            Debug.Log(panelDic[panelName].gameObject);
        });
    }

    public void HidePanel(string panelName)
    {
        if(panelDic.ContainsKey(panelName))
        {
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName); 
            Debug.Log("Hide");
        }
    }

}
