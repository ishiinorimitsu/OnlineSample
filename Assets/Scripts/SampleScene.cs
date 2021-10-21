using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SampleScene : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        //�v���C���[���g�̖��O���hPlayer�h�ɐݒ肷��B
        PhotonNetwork.NickName = "Player";

        //PhotonServerSettings�̐ݒ���e�𗘗p���ă}�X�^�[�T�[�o�[�ɐڑ�����B
        PhotonNetwork.ConnectUsingSettings();
    }

    //�}�X�^�[�T�[�o�[�ւ̐ڑ������������Ƃ��ɌĂ΂�鏈���i11�s�ڂ�������OK��������Ă΂��B�j
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();

        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);      //�����i�쐬���镔���̖��O�A�����̃I�v�V�����ݒ�A���r�[�̏����ݒ�j
        //�܂����ɁhRoom�h�Ƃ������O�̕��������邩�����A����Γ���A�Ȃ���΍��B
    }

    public override void OnJoinedRoom()     //�����ɓ������Ƃ��Ɏ����I�ɌĂ΂��B
    {
        //base.OnJoinedRoom();
        // �����_���ȍ��W�Ɏ��g�̃A�o�^�[�i�l�b�g���[�N�I�u�W�F�N�g�j�𐶐�����
        Vector3 position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3));

        PhotonNetwork.Instantiate("Avatar",position,Quaternion.identity);       //�����iResource�t�H���_�ɂ���Q�[���I�u�W�F�N�g�̖��O�A�ǂ��ɁA�ǂ�Ȍ����Łj
    }
}
