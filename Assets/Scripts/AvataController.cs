using Photon.Pun;
using UnityEngine;

public class AvataController : MonoBehaviourPunCallbacks        // MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
{
    void Update()
    {
        // ���g�����������I�u�W�F�N�g�����Ɉړ��������s��
        if (photonView.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

            transform.Translate(6 * Time.deltaTime* input.normalized);
        }
    }
}
