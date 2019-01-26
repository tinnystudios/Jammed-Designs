using System.Collections;
using UnityEngine;

public class Dialouge : SingletonMonoBehaviour<Dialouge>
{
    public DialougeBox DialougeBox;

    public void Hide()
    {
        DialougeBox.Hide();
    }

    public Coroutine Run()
    {
        return StartCoroutine(_Run());
    }

    private IEnumerator _Run()
    {
        yield return new WaitForSeconds(3.0F);

        DialougeBox.Show();
        DialougeBox.SetText("");
        yield return new WaitForSeconds(1);

        AudioManager.Instance.PlayTyping();

        yield return AnimateText("Hi I'm Miss Jam");
        yield return new WaitForSeconds(1);
        yield return AnimateText("I just moved in recently and would love a clicky helping hand");
        yield return new WaitForSeconds(2);

        AudioManager.Instance.PlayTyping();

        yield return AnimateText("Something warm and fuzzy");
        yield return new WaitForSeconds(2);
        DialougeBox.Hide();
    }

    private IEnumerator AnimateText(string text)
    {

        string currentText = "";

        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i + 1);
            DialougeBox.SetText(currentText);
            yield return new WaitForSeconds(0.02F);
        }
    }
}

/*I want a <color=yellow>warm</color> home with <color=yellow>plenty of chairs</color>, a <color=yellow>TV</color>, and a <color=yellow>fireplace</color>
*/