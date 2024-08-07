using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Student2
{
    public int age;
    public string name;

    public Student2(){}

    public Student2(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

public class MrTang2
{
    public string name;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    //public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student2 s1;
    public List<Student2> s2s;

    private int privateI;
    protected int protectedI;
}



public class Lesson_02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(Application.persistentDataPath);
        MrTang2 t = new MrTang2();
        t.name = "MrTang";
        t.age = 18;
        t.sex = false;
        t.testF = 1.4f;
        t.testD = 1.4;

        t.ids = new int[] { 1, 2, 3, 4 };
        t.ids2 = new List<int>() { 1, 2, 3 };
        //t.dic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };
        t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

        t.s1 = new Student2(1, "小红");
        t.s2s = new List<Student2>() { new Student2(2, "小明"), new Student2(3, "小强") };

        string jsonStr = JsonMapper.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/MrTang2.json", jsonStr);

        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTang2.json");
        MrTang2 t2 =JsonMapper.ToObject<MrTang2>(jsonStr);
        print(t2.s1.name);

        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/ItemData.json");
        ItemData[] arr = JsonMapper.ToObject<ItemData[]>(jsonStr);
        print(arr[1].icon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class ItemData
{
    public int id;
    public string name;
    public string icon;
    public string type;
    public string tips;
}