using UnityEngine;
using UnityEngine.UI;

public class ViewResultBlock : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public void SetValueScore(int score)
    {
        if (score == 0)
        {
            _scoreText.text = "-";
        }
        else
        _scoreText.text = score.ToString();
    }
}
