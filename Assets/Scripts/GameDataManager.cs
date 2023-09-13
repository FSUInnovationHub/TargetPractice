using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static GameDataManager;

public class GameDataManager : MonoBehaviour
{

    

    public class Score : MonoBehaviour
    {
        [SerializeField] public string name;
        [SerializeField] public int score;

    }

    public class ScoreBoard : MonoBehaviour
    {
        public string path = Application.persistentDataPath + "/Saves";

        [SerializeField] public List<Score> Score = new List<Score>();

        public void SortScoreBoard()
        {
            var sortedScore = Score.OrderBy(x => x.score);

            Score = sortedScore.ToList();
            Score.Reverse();
        }

        public void toJson(ScoreBoard gameInput)
        {
            CheckJson();

            string Input = JsonUtility.ToJson(gameInput);

            File.WriteAllText(path + "/localScores.json", Input);

        }



        public void fromJson()
        {
            CheckJson();
            Console.WriteLine("Reading from Json");
        }

        public void CheckJson()
        {

            if (!Directory.Exists(path))
            {
                Debug.Log("no folder!");
                Directory.CreateDirectory(path);
                CheckJson();
                return;
            }
            else
            {
                //Debug.Log("folder found!");
            }

            if (!File.Exists(path + "/localScores.json"))
            {
                Debug.Log("no file!");
                File.Create(path + "/localScores.json");
                CheckJson();
                return;
            }
            else
            {
                //Debug.Log("file found!");
            }
        }
    }





}
