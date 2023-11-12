using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyDamageText : MonoBehaviour
{
    private TMP_Text textMesh;
    private float disappearTimer = 1f;
    private Color textColor;
    private float scaleSpeed = 0.5f; // Adjust the scale decrease speed

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Start()
    {
        if (textMesh != null)
        {
            textColor = textMesh.color;
        }
        else
        {
            Debug.LogError("TMP_Text component not found on the GameObject.", this);
        }
    }

    void Update()
    {
        float moveYSpeed = 66f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;

        if (textMesh != null)
        {
            // Decrease the size of the object over time
            transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;

            if (disappearTimer < 0)
            {
                float disappearSpeed = 3f;
                textColor.a -= disappearSpeed * Time.deltaTime;
                textMesh.color = textColor;

                
                if (textColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Debug.LogError("TMP_Text component not found on the GameObject.", this);
        }
    }
}
