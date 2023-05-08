using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;


public class PlayerData
{

    public string _Nickname;
    public int _Score;
    public PlayerData(string nickname, int score)
    {
        _Nickname = nickname;
        _Score = score;
    }

}

public class GameMgr
{
    private static GameMgr instance = null;
    public string _Nickname = "";
    public int _Score = 0;

    public bool _isFirst = false;

    public int _mainSoundCnt = 0;

    public static GameMgr GetIns
    {
        get
        {
            if (instance == null) instance = new GameMgr();
            return instance;
        }
    }

    public List<PlayerData> _listData = new List<PlayerData>();

    string _SavePath = "Player.data";
    public void SaveData()
    {
        LoadData();

        PlayerData data = new PlayerData(_Nickname, _Score);
        _listData.Add(data);

        FileStream fs = new FileStream(_SavePath, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(_listData.Count);
        for (int i = 0; i < _listData.Count; ++i)
        {
            bw.Write(_listData[i]._Nickname);
            bw.Write(_listData[i]._Score);
        }

        bw.Close();
        fs.Close();
    }

    public void LoadData()
    {
        try
        {
            _listData.Clear();

            FileStream fs = new FileStream(_SavePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            int count = br.ReadInt32();
            for (int i = 0; i < count; ++i)
            {
                PlayerData data = new PlayerData(br.ReadString(), br.ReadInt32());
                _listData.Add(data);
            }

            br.Close();
            fs.Close();

            _listData = _listData.OrderByDescending(l => l._Score).ToList();
        }

        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void 

}
