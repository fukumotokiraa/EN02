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
            arrowImage.gameObject.SetActive(true); // ����\��
            arrowImage.rectTransform.position = clickPosition; // ���̏����ʒu��ݒ�
            arrowImage.rectTransform.sizeDelta = new Vector2(0, arrowImage.rectTransform.sizeDelta.y); // ���̒��������Z�b�g
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            Debug.Log(dist);
            //�x�N�g���̒������Z�o
            float size = dist.magnitude;
            //�x�N�g������p�x(�ʓx�@)���Z�o
            float angleRed = Mathf.Atan2(dist.y, dist.x);
            //���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
            arrowImage.rectTransform.position = clickPosition;
            //���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ�����Z����]
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRed * Mathf.Rad2Deg);
            //���̉摜�̑傫�����h���b�O���������ɍ��킹��
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        if (Input.GetMouseButtonUp(0))
        {
            // ���̈ʒu�ƃT�C�Y�����Z�b�g
            arrowImage.rectTransform.position = Vector3.zero;
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
        }

    }
}
