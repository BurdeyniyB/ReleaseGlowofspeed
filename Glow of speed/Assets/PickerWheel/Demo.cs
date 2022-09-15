using UnityEngine ;
using EasyUI.PickerWheelUI ;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class Demo : MonoBehaviour {
   [SerializeField] private Button uiSpinButton ;
   [SerializeField] private Text uiSpinButtonText ;

   [SerializeField] private PickerWheel pickerWheel ;
   [SerializeField] private GameObject button ;
   [SerializeField] private GameObject buttonads ;
   [SerializeField] private SkinManager skinManager;
   public bool scene_manager;
   public string SceneName;


   private void Start () {
      uiSpinButton.onClick.AddListener (() => {

         uiSpinButton.interactable = false ;
         uiSpinButtonText.text = "Spinning" ;

         pickerWheel.OnSpinEnd (wheelPiece => {
            Debug.Log (
               @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label
               + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
            ) ;

            uiSpinButton.interactable = true ;
            uiSpinButtonText.text = "Spin" ;
            if(wheelPiece.Label == "Coins")
            {
               int x = PlayerPrefs.GetInt("Money");
               x += wheelPiece.Amount;
               PlayerPrefs.SetInt("Money", x);
            }

            if(wheelPiece.Label == "Ticket")
            {
               int x = PlayerPrefs.GetInt("Ticket");
               x += wheelPiece.Amount;
               PlayerPrefs.SetInt("Ticket", x);
            }

            if(wheelPiece.Label == "Diamond")
            {
               int x = PlayerPrefs.GetInt("diamonds");
               x += wheelPiece.Amount;
               PlayerPrefs.SetInt("diamonds", x);
            }

            if(wheelPiece.Label == "Voud")
            {
              if (!skinManager.IsUnlocked(17))
               {
                 skinManager.Unlock(17);
                 skinManager.SelectSkin(17);
               }
             else
               {
                 int x = PlayerPrefs.GetInt("Money");
                 x += 30000;
                 PlayerPrefs.SetInt("Money", x);
               }
            }

            if(wheelPiece.Label == "Ronny")
            {
              if (!skinManager.IsUnlocked(16))
               {
                 skinManager.Unlock(16);
                 skinManager.SelectSkin(16);
               }
             else
               {
                 int x = PlayerPrefs.GetInt("Money");
                 x += 25000;
                 PlayerPrefs.SetInt("Money", x);
               }
            }

            if(wheelPiece.Label == "Fragust")
            {
              if (!skinManager.IsUnlocked(15))
               {
                 skinManager.Unlock(15);
                 skinManager.SelectSkin(15);
               }
             else
               {
                 int x = PlayerPrefs.GetInt("Money");
                 x += 25000;
                 PlayerPrefs.SetInt("Money", x);
               }
            }

            if(wheelPiece.Label == "Raiky")
            {
              if (!skinManager.IsUnlocked(19))
               {
                 skinManager.Unlock(19);
                 skinManager.SelectSkin(19);
               }
             else
               {
                 int x = PlayerPrefs.GetInt("Money");
                 x += 50000;
                 PlayerPrefs.SetInt("Money", x);
               }
            }

            if(wheelPiece.Label == "Varan")
            {
              if (!skinManager.IsUnlocked(18))
               {
                 skinManager.Unlock(18);
                 skinManager.SelectSkin(18);
               }
             else
               {
                 int x = PlayerPrefs.GetInt("Money");
                 x += 50000;
                 PlayerPrefs.SetInt("Money", x);
               }
            }
            // diamonds
            button.SetActive(false);
            buttonads.SetActive(true);

            if(scene_manager)
            {
            SceneManager.LoadScene(SceneName);
            }
         }) ;
   

         pickerWheel.Spin () ;

      }) ;

   }

}
