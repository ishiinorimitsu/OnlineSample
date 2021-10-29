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

    // ��ʊO�Ɉړ�������폜����
    // �iUnity�̃G�f�B�^�[��ł̓V�[���r���[�̉�ʂ��e������̂Œ��Ӂj
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
