using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Student
{
    public int age;
    public string name;

    public Student(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

public class MrTang
{
    public string name;
    public int age;  
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<int,string> dic;
    public Dictionary<string,string> dic2;

    public Student s1;
    public List<Student> s2s;

    [SerializeField]
    private int privateI;
    [SerializeField]
    protected int protectedI;
}

public class Lesson_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/Test.json", "存储的Json文件");

        string str = File.ReadAllText(Application.persistentDataPath + "/Test.json");
        print(str);

        MrTang t = new MrTang();
        t.name = "MrTang";
        t.age = 18;
        t.sex = false;
        t.testF = 1.4f;
        t.testD = 1.4;

        t.ids = new int[] { 1, 2, 3, 4 };
        t.ids2 = new List<int>() { 1, 2, 3 };
        t.dic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };
        t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

        t.s1 = new Student(1, "小红");
        t.s2s = new List<Student>() { new Student(2, "小明"), new Student(3, "小强") };

        string jsonStr = JsonUtility.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/MrTang.json", jsonStr);

        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTang.json");
        MrTang t2 = JsonUtility.FromJson<MrTang>(jsonStr);
        print(t2.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
