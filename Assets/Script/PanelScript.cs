using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public Text correctAnswerText;
    public Text wrongAnswerText;

    public void SetCorrectAnswerText(string text)
    {
        correctAnswerText.text = text;
    }

    public void SetWrongAnswerText(string text)
    {
        wrongAnswerText.text = text;
    }
}
