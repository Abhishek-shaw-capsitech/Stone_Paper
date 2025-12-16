// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class GameController : MonoBehaviour
// {
//     public Sprite[] choiceSprites;
//     public Sprite questionMarkSprite;
//     public Sprite replaySprite;
//     [Header("UI Reference")]
//     public UnityEngine.UI.Image PlayerChoiceImage;
//     public UnityEngine.UI.Image aiChoiceImage;
//     public TextMeshProUGUI resultText;
//     public TextMeshProUGUI scoreText;
//     public Button rockButton;
//     public Button paperButton;
//     public Button scissorButton;
//     public Button replayButton;
//     private int playerScore = 0;
//     private int aiScore = 0;

//     void Start()
//     {
//         rockButton.onClick.AddListener(() => play(0));
//         paperButton.onClick.AddListener(() => play(1));
//         scissorButton.onClick.AddListener(() => play(2));
//         replayButton.onClick.AddListener(ResetGame);
//         ResetGame();
//     }
//     void play(int playerChoice)
//     {
//         SetButtonsInteractable(false);
//         replayButton.gameObject.SetActive(true);
//         int aiChoice = Random.Range(0, 3);
//         PlayerChoiceImage.sprite = choiceSprites[playerChoice];
//         aiChoiceImage.sprite = choiceSprites[aiChoice];
//         if (playerChoice == aiChoice)
//         {
//             resultText.text = "IT'S A DRAW!";
//             resultText.color = Color.white;
//         }
//         else if (
//             (playerChoice == 0 && aiChoice == 2) ||
//             (playerChoice == 1 && aiChoice == 0) ||
//             (playerChoice == 2 && aiChoice == 1))  
//         {
//             resultText.text = "YOU WIN!";
//             resultText.color = Color.green;
//             playerScore++;
//         }
//         else
//         {
//             resultText.text = "YOU LOSE!";
//             resultText.color = Color.red;
//             aiScore++;
//         }

//         scoreText.text = $"Score: {playerScore} - {aiScore}"; 
//     }
//     void ResetGame()
//     {
//         Debug.Log("reset is clicked");
//         PlayerChoiceImage.sprite = questionMarkSprite;
//         aiChoiceImage.sprite = questionMarkSprite;
//         resultText.text = "Choose!";
//         resultText.color = Color.white;
//         replayButton.gameObject.SetActive(false);
//         SetButtonsInteractable(true);
//     }
//     void SetButtonsInteractable(bool interactable)
//     {
//         rockButton.interactable = interactable;
//         paperButton.interactable = interactable;
//         scissorButton.interactable = interactable;
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }



using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite[] choiceSprites;
    public Sprite questionMarkSprite;
    [Header("UI Reference")]
    public Image PlayerChoiceImage;
    public Image aiChoiceImage;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;
    public Button rockButton;
    public Button paperButton;
    public Button scissorButton;
    public Button replayButton;
    private int playerScore = 0;
    private int aiScore = 0;
    private bool matchOver = false;

    void Start()
    {
        rockButton.onClick.AddListener(() => play(0));
        paperButton.onClick.AddListener(() => play(1));
        scissorButton.onClick.AddListener(() => play(2));
        replayButton.onClick.AddListener(ResetGame);
        ResetGame();
    }

    void play(int playerChoice)
    {
        SetButtonsInteractable(false);
        replayButton.gameObject.SetActive(true);
        int aiChoice = Random.Range(0, 3);
        PlayerChoiceImage.sprite = choiceSprites[playerChoice];
        aiChoiceImage.sprite = choiceSprites[aiChoice];
        if (playerChoice == aiChoice)
        {
            resultText.text = "IT'S A DRAW!";
            resultText.color = Color.white;
        }
        else if (
            (playerChoice == 0 && aiChoice == 2) ||
            (playerChoice == 1 && aiChoice == 0) ||
            (playerChoice == 2 && aiChoice == 1))
        {
            resultText.text = "YOU WIN!";
            resultText.color = Color.green;
            playerScore++;
        }
        else
        {
            resultText.text = "YOU LOSE!";
            resultText.color = Color.red;
            aiScore++;
        }

        scoreText.text = $"Score: {playerScore} - {aiScore}";

        if (playerScore >= 2 || aiScore >= 2)
        {
            matchOver = true;
            if (playerScore >= 2)
            {
                resultText.text = "YOU WIN THE MATCH!";
                resultText.color = Color.green;
            }
            else
            {
                resultText.text = "AI WINS THE MATCH!";
                resultText.color = Color.red;
            }
        }
    }

    void ResetGame()
    {
        PlayerChoiceImage.sprite = questionMarkSprite;
        aiChoiceImage.sprite = questionMarkSprite;
        resultText.text = "Choose!";
        resultText.color = Color.white;
        replayButton.gameObject.SetActive(false);
        SetButtonsInteractable(true);

        if (matchOver)
        {
            playerScore = 0;
            aiScore = 0;
            matchOver = false;
            scoreText.text = $"Score: {playerScore} - {aiScore}";
        }
    }

    void SetButtonsInteractable(bool interactable)
    {
        rockButton.interactable = interactable;
        paperButton.interactable = interactable;
        scissorButton.interactable = interactable;
    }

    void Update() { } // Empty for now
}

// Brackly notes : 
// use fixedupdate instead of update 
// vector3 - stores 3 float numbers 
// collision is type 
// void OnCollisionEnter(collision collisionInfo)
// collisionInfo.collider.name   // collider-- samne wala jo collide kia hamse 
// collisionInfo.collider.Tag == "..." -- tag of samne wala
// if made changes in the prefab then it also chage its respective where ever its used 
// ForceMode.VelocityChange -- used to instantly chnage the rigidbodies velocity by the amount of force u apply ignoring the mass
// Drag - a inspector property which represents air resistance the more the drag the more is the air resistance 
// ctrl+p -- run 
//lightning panel is anoother pannel like inspecter
// lecture no. 8 --
//canva -- for the pannels 
//Roboto.com for various fonts 
//Transformation comp responsible for position , rotation and scale 
// to play with user interface via code use using UnityEngine.UI
// public Text scoreText
// scoreText.text = player.position.z.ToString();  // to deisplay only inwhole number use-- .ToString("0");
// FindObjectOfType<GameManager>().EndGame()  // bina variable reference ka GameManager ko access kia and EndGame ke defination ko use kia 
// To restart the game or for restart function , we use -- using UnityEngine.SceneManagement -- then 
//  in Restart function use : SceneManager.LoadScene("sceneKaName") 
// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
// thoda delay mai restrt karana hai not instant :
//Invoke("Restart",2f);  -- Restart func called after 2f
// while performing build every scene shall be present their 
// oncollision enter will not work if your collider is marked as trigger we need to write onTriggerEnter in script instead  
//public GameManager manager
// lec 10 animation
//

















// from project few learning :
// Mathf.Clamp( , , ) -- position ka range ko limit karna ho to we can use this 
// Time.time  -- containg time since the game had started 
//public void EndGame()
//SceneManager.LoadScene(SceneManager.GetActiveSeen().buildIndex)
// void OnEnterCollision2d
// findobjectoftype<GameManager>().EndGame();
// to use corotine --- using System.Collections
// when we just load a new scene we dont have any time to see the matrix effect so we are going to use coroutine 
//  