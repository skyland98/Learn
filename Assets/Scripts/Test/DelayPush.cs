using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPush : MonoBehaviour
{
    public string name1 = "123";

    private void OnEnable()
    {
        Invoke("Push", 1);
    }
    void Push()
    {
        PoolMgr.GetInstance().PushObj(this.gameObject.name,this.gameObject);
        EventCenter.GetInstance().EventTrigger("Dead",this);
    }

}
