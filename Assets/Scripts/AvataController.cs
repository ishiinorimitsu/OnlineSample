using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class AvataController : MonoBehaviourPunCallbacks ,IPunObservable      // MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
{
    private const float MaxStamina = 6f;       //constは、その値を固定するという意味(変数)

    [SerializeField]
    private Image staminaBar = default;

    private float currentStamina = MaxStamina;

    void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

            if(input.sqrMagnitude > 0)      //そもそもMagnitudeはVector3の各値を2乗して足してルートする。sqrをつけたほうが早い
            {
                currentStamina = Mathf.Max(0f, currentStamina - Time.deltaTime);        //大きいほうの値を返す。currentStaminaが0以下になるときは0のほうを返す

                transform.Translate(6 * Time.deltaTime * input.normalized);
            }
            else
            {
                currentStamina = Mathf.Min(currentStamina + Time.deltaTime*2,MaxStamina);       //大きいほうの値を返す。currentStaminaがMaxStamina以下になるときはMaxStaminaのほうを返す
            }
        }

        //スタミナをゲージに反映させる
        staminaBar.fillAmount = currentStamina / MaxStamina;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)      //第一引数が動きがあったゲームオブジェクト、第二引数はわからない
    {
        if (stream.IsWriting)       //自分（動く方）が情報を送る側の時
        {
            stream.SendNext(currentStamina);
        }
        else
        {
            currentStamina = (float)stream.ReceiveNext();
        }
    }
}
