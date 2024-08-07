using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseManager<ResMgr>
{
   
    //ͬ��������Դ
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);

        if (res is GameObject)
            return GameObject.Instantiate(res);
        else//TextAsset AudioClip
            return res;
    }

    //�첽������Դ
    public void LoadAsync<T>(string name,UnityAction<T> callback) where T : Object
    {
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadAsync(name, callback));

    }

    private IEnumerator ReallyLoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);
        yield return r;

        if (r.asset is GameObject)
            callback(GameObject.Instantiate(r.asset) as T);
        else
            callback(r.asset as T);
    }

}
