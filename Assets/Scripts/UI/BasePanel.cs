using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    protected Dictionary<string,List<UIBehaviour>> controlDic = new Dictionary<string,List<UIBehaviour>>();
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void OnEnable()
    {
        
        //FindChildren<Image>();
        //FindChildren<Text>();
        //FindChildren<Toggle>();
        //FindChildren<Slider>();
        //FindChildren<ScrollRect>();
    }

    public virtual void ShowMe()
    {

    }
    public virtual void HideMe() 
    { 

    }

    protected T GetControl<T>(string controlName) where T : UIBehaviour
    {
        if (controlDic.ContainsKey(controlName))
        {
            for(int i = 0; i < controlDic[controlName].Count; i++)
            {
                if (controlDic[controlName][i] is T)
                    return controlDic[controlName][i] as T;
            }
        }
        return null;
    }
         
    protected void FindChildren<T>() where T:UIBehaviour
    {
        //Debug.Log("Ω¯»Î");
        T[] child = this.GetComponentsInChildren<T>();
        string objName;

        for (int i =0;i<child.Length;i++)
        {
            objName = child[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
                controlDic[objName].Add(child[i]);

            else
            {
                controlDic.Add(objName, new List<UIBehaviour>() { child[i] });
                
                //Debug.Log("’“µΩ");
            }
            
            
        }
    }

}
