using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class ReadWriteFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        writeContent(Application.dataPath, "fileName", "hello!");
        writeContent(Application.dataPath, "fileName", "how r u");

        ArrayList info = LoadContent(Application.dataPath, "fileName");
        foreach (string str in info)
        {
            Debug.Log(str);
        }
	}

    ArrayList LoadContent(string filePath, string fileName)
    {
        StreamReader sRead = null;
        try
        {
            sRead = File.OpenText(filePath + "//" + fileName);
        }
        catch (Exception e)
        {
            e.ToString();
            return null;
        }
        string line;
        ArrayList list = new ArrayList();
        while ((line = sRead.ReadLine()) != null)
        {
            list.Add(line);
        }
        sRead.Close();
        sRead.Dispose();
        return list;
    }

    void writeContent(string filePath, string fileName, string content)
    {
        StreamWriter swrite;
        FileInfo file = new FileInfo(filePath + "//" + fileName);
        if (!file.Exists)
        {
            swrite = file.CreateText();
        }
        else
        {
            swrite = file.AppendText();
        }
        swrite.WriteLine(content);
        swrite.Close();
        swrite.Dispose();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
