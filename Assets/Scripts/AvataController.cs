using Photon.Pun;
using UnityEngine;

public class AvataController : MonoBehaviourPunCallbacks        // MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
{
    void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

            transform.Translate(6 * Time.deltaTime* input.normalized);
        }
    }
}
