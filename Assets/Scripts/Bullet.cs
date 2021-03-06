using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 velocity;

    public void Init(Vector3 origin,float angle)
    {
        transform.position = origin;
        velocity = 9 * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    // 画面外に移動したら削除する
    // （Unityのエディター上ではシーンビューの画面も影響するので注意）
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
