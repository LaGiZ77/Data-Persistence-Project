using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public string playerName;
    public Highscore highscore;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }

    [System.Serializable]
    public class Highscore {
        public string playerName;
        public int score;

        public Highscore(string playerName, int score) {
            this.playerName = playerName;
            this.score = score;
        }
    }

    [System.Serializable]
    class SaveData {
        public Highscore highscore;
    }


    public void SaveHighscore(int newHighscore) {
        SaveData saveData = new SaveData();
        saveData.highscore = new Highscore(playerName, newHighscore);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighscore() {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            highscore = saveData.highscore;
        }
        else {
            highscore = new Highscore("Name", 0);
        }
    }
}

