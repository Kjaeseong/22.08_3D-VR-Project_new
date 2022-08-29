using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : SingletonBehaviour<FileManager>
{
    public List<Sprite> Icon = new List<Sprite>();
    public List<Dictionary<string, object>> CSV = new List<Dictionary<string, object>>();

    private void Start()
    {
        CsvLoading();
        IconLoading();
    }

    void CsvLoading()
    {
        CSV = CSVReader.Read("Item/ItemData");
    }

    void IconLoading()
    {
        for (int i = 0; i < CSV.Count; i++)
        {
            Icon.Add(Resources.Load<Sprite>("Item/Icon" + (i + 1).ToString()));
        }
    }


}
