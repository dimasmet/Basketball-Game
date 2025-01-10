using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WrapTopResults
{
    public Result[] results;
}

[System.Serializable]
public class Result
{
    public int scoreValue;
}

public class TopResultHandler : MonoBehaviour
{
    [SerializeField] private ViewResultBlock[] viewResultBlocks;

    [SerializeField] private WrapTopResults wrapTopResults;

    private void Start()
    {
        GetSave();
        UpdateView();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(wrapTopResults);
        PlayerPrefs.SetString("TopResult", json);
    }

    public void GetSave()
    {
        string json = PlayerPrefs.GetString("TopResult");
        if (json != "")
        {
            wrapTopResults = JsonUtility.FromJson<WrapTopResults>(json);
        }
    }

    private void UpdateView()
    {
        for (int i = 0; i < wrapTopResults.results.Length; i++)
        {
            viewResultBlocks[i].SetValueScore(wrapTopResults.results[i].scoreValue);
        }
    }

    public bool CheckResult(int scoreValue)
    {
        int num = -1;

        bool isRecord = false;

        for (int i = 0; i < wrapTopResults.results.Length; i++)
        {
            if (scoreValue > wrapTopResults.results[i].scoreValue)
            {
                num = i;
                isRecord = true;
                break;
            }
        }

        if (num != -1)
        {
            int shifts = 1;

            for (int i = wrapTopResults.results.Length - shifts - 1; i >= num; i--)
            {
                if (i + shifts < wrapTopResults.results.Length)
                    wrapTopResults.results[i + shifts].scoreValue = wrapTopResults.results[i].scoreValue;
            }
            wrapTopResults.results[num].scoreValue = scoreValue;

            Save();

            UpdateView();
        }

        return isRecord;
    }
}
