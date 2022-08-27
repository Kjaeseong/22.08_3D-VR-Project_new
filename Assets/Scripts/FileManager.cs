using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : SingletonBehaviour<FileManager>
{
    public Sprite Image;
    public List<Sprite> ImageList;
    public int TotalItem; 

    //public List<Dictionary<string, object>> CSV = new List<Dictionary<string, object>>();





    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("File Manager Awake");

        //CSV = CSVReader.Read("Item/ItamData");
        Debug.Log("CSV Reading");

    }



    // Update is called once per frame
    void Update()
    {
        
    }


}
