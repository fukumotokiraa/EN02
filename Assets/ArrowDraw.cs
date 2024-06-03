using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    public Image arrowImage;
    private Vector3 clickPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
            arrowImage.gameObject.SetActive(true); // 矢印を表示
            arrowImage.rectTransform.position = clickPosition; // 矢印の初期位置を設定
            arrowImage.rectTransform.sizeDelta = new Vector2(0, arrowImage.rectTransform.sizeDelta.y); // 矢印の長さをリセット
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            Debug.Log(dist);
            //ベクトルの長さを算出
            float size = dist.magnitude;
            //ベクトルから角度(弧度法)を算出
            float angleRed = Mathf.Atan2(dist.y, dist.x);
            //矢印の画像をクリックした場所に画像を移動
            arrowImage.rectTransform.position = clickPosition;
            //矢印の画像をベクトルから算出した角度を度数法に変換してZ軸回転
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRed * Mathf.Rad2Deg);
            //矢印の画像の大きさをドラッグした距離に合わせる
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        if (Input.GetMouseButtonUp(0))
        {
            // 矢印の位置とサイズをリセット
            arrowImage.rectTransform.position = Vector3.zero;
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
        }

    }
}
