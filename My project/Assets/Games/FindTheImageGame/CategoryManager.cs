using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class CategoryManager : MonoBehaviour
{
    // This function is called when a category is selected
    public void OnCategorySelected(int categoryIndex)
    {
        // Save the selected category index in PlayerPrefs
        PlayerPrefs.SetInt("SelectedCategory", categoryIndex);

        // Load the "FindTheImageEnglish" scene, where the quiz/game starts
        SceneManager.LoadScene("FindTheImageEnglish");
    }
}
