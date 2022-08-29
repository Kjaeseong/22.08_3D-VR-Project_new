using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : SingletonBehaviour<FileManager>
{
    public Sprite Image;
    public List<Sprite> ImageList;
    public int TotalItem;

    List<Dictionary<string, object>> CSV = new List<Dictionary<string, object>>();





    private void Start()
    {
        CSV = CSVReader.Read("Item/ItemData");
        TotalItem = CSV.Count;

    }



    // Update is called once per frame
    void Update()
    {
        
    }


}
