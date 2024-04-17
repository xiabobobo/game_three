using UnityEngine;

public class Pice : MonoBehaviour
{
    // 定义是否允许拖拽
    private bool allowDrag = false;

    // 记录物体与鼠标之间的偏移量
    private Vector3 offset;

    // 目标位置的局部坐标
    public Vector3 targetLocalPosition;
    
    public AudioClip clickSound;

    // 音频源
    private AudioSource audioSource;
    
    

    void Start()
    {
        // 获取物体上的音频源组件，如果没有则添加一个
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 设置音频剪辑
        audioSource.clip = clickSound;
    }


    void OnMouseDown()
    {
         if (clickSound != null)
        {
            audioSource.Play();
        }
        // 计算偏移量
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        allowDrag = true;
    }

    void OnMouseDrag()
    {
        // 如果允许拖拽，更新物体位置
        if (allowDrag)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        // 停止拖拽
        allowDrag = false;

        // 将物体移动到特定位置（局部坐标）
        transform.localPosition = targetLocalPosition;
    }
}
