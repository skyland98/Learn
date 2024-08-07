using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��������ԣ����ٳ����Ӷ�
/// </summary>
public class EventCenter : BaseManager<EventCenter>
{
    //key - �¼������֣����磺������������������ȵȣ�
    //value - ��Ӧ���� ��������¼� ��Ӧ��ί�к���
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();

    //����¼�����
    public void AddEventListener(string name, UnityAction<object> action)
    {
        if(eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        }
        else
        {
            eventDic.Add(name, action);
        }
    }

    public void RemoveEventListener(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] -= action;
        }
        
    }

    //�¼�����
    public void EventTrigger(string name,object info)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name].Invoke(info);
        }
    }

    public void Clear()
    {
        eventDic.Clear();
    }

}
