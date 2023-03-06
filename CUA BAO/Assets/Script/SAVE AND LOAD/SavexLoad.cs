using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class SavexLoad : MonoBehaviour
{
    public InputField _IDwords;

    public string _gettime;

    public Timer _gettimuu;

    private void Update()
    {
        _bbb();
    }
    public void Save()
    {
        DummyData data = new DummyData();
        data._dgettime = _gettime;

        //_gettime = _gettimuu._aaa();

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/ItsDummyData.json", json);
    }
    
    public void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/ItsDummyData.json");
        DummyData data = JsonUtility.FromJson<DummyData>(json);

        _IDwords.text = data._dgettime;
    }

    public void _bbb()
    {
        _gettime = _gettimuu._aaa();
    }

}
