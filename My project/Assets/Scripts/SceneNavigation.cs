using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void LoadAvsAnRule()
    {
        SceneManager.LoadScene("A Vs. An"); 
    }

    public void LoadPluralNouns()
    {
        SceneManager.LoadScene("Plural"); 
    }
}
