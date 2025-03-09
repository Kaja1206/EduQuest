using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryManager : MonoBehaviour
{
    public void OnCategorySelected(int categoryIndex)
    {
        PlayerPrefs.SetInt("SelectedCategory", categoryIndex);

        SceneManager.LoadScene("English 1");
    }
}
