using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public string filepath = "log.txt";

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        WritetoFile("You have opened the game!");
    }

    private void OnApplicationQuit()
    {
        WritetoFile("You have closed the game!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WritetoFile("Space key was pressed");
        }
    }

    private void CreateFile()
    {
        if (!File.Exists(filepath))
        {
            File.Create(filepath).Close();
        }
    }

    public void WritetoFile(string message)
    {
        using (StreamWriter streamWriter = new StreamWriter(filepath, true)) 
        {
            streamWriter.WriteLine(DateTime.Now + ": " + message);
        }
    }
}
