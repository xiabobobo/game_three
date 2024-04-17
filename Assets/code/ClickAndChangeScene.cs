using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickAndChangeScene : MonoBehaviour
{
    // 需要显示的文本
    public string displayText = "请点击小狐狸进入答题";

    // UI Text 对象
    public Text infoText;

    // 是否已经显示了文本
    private bool textDisplayed = false;

    void Start()
    {
        // 确保文本对象存在并隐藏
        if (infoText != null)
        {
            infoText.gameObject.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        // 如果文本已经显示，则切换场景
        if (textDisplayed)
        {
           // SceneManager.LoadScene("YourNextSceneName");
            return;
        }

        // 显示文本
        ShowText(displayText);
    }

    // 显示文本信息
    void ShowText(string text)
    {
        // 确保文本对象存在
        if (infoText != null)
        {
            // 设置文本内容
            infoText.text = text;

            // 显示文本
            infoText.gameObject.SetActive(true);

            // 标记已经显示文本
            textDisplayed = true;
        }
    }
}
