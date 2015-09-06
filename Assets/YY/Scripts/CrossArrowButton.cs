using UnityEngine;
using System.Collections;

public class CrossArrowButton : MonoBehaviour {
	
	private GameObject playerObject;
	public bool  useCurves = true;				// Mecanimでカーブ調整を使うか設定する
	public float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）

	// キャラクターコントローラ（Boxコライダ）の参照
	private BoxCollider col;
	private Rigidbody rb;
	// キャラクターコントローラの移動量
	private Vector3 velocity;
	// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
	private float orgColHight;
	private Vector3 orgVectColCenter;
	Animator anim;

	public  float walsSpeed   = 4.0f;	// 移動速度
	public  float rotateSpeed = 2.0f;	// 旋回速度
	private bool push = false; 			// ボタンが押されているか？

	public void StartPush(){ push = true;  }
	public void StopPush() { push = false; }
	
	void Start(){
		playerObject = GameObject.Find ("Player");

		// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
		col = playerObject.GetComponent<BoxCollider> ();
		rb  = playerObject.GetComponent<Rigidbody> ();
		anim = playerObject.GetComponent<Animator> ();
		// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
		orgVectColCenter = col.center;
	}

	void FixedUpdate()
	{
		if(push){

			anim.SetFloat ("Speed",1);

			if (gameObject.name == "UpButton") {

				// 以下、キャラクターの移動処理
				velocity = new Vector3 (0, 0, walsSpeed * 2);
				// キャラクターのローカル空間での方向に変換
				velocity = transform.TransformDirection (velocity);
				playerObject.transform.localPosition += velocity * Time.fixedDeltaTime;
			}
			if (gameObject.name == "DownButton") {
				
				// 以下、キャラクターの移動処理
				velocity = new Vector3 (0, 0, -walsSpeed);
				// キャラクターのローカル空間での方向に変換
				velocity = transform.TransformDirection (velocity);
				playerObject.transform.localPosition += velocity * Time.fixedDeltaTime;
			}
			if (gameObject.name == "LeftButton") {
				
				// 左右のキー入力でキャラクタをY軸で旋回させる
				playerObject.transform.Rotate (0, -rotateSpeed, 0);
			}
			if (gameObject.name == "RightButton") {
				
				// 左右のキー入力でキャラクタをY軸で旋回させる
				playerObject.transform.Rotate (0,  rotateSpeed, 0);
			}
		}
	}
}
