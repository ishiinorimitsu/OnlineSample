using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text nameLabel = GetComponent<TMP_Text>();

        // �v���C���[���ƃv���C���[ID��\������
        nameLabel.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";     //���̍s�́h���h�ȍ~�ł��B
    }
}
