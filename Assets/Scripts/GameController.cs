using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public Text ScoreText;

    public static GameController instance; //seguindo o tutorial

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScoreText()
    {
        ScoreText.text = TotalScore.ToString();
    }
}
