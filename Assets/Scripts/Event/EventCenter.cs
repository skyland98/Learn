using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 降低耦合性，减少程序复杂度
/// </summary>
public class EventCenter : BaseManager<EventCenter>
{
    //key - 事件的名字（比如：怪物死亡、玩家死亡等等）
    //value - 对应的是 监听这个事件 对应的委托函数
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();

    //添加事件监听
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

    //事件触发
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
