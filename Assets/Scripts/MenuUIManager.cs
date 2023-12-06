using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Image musicImage;
    [SerializeField]
    private Sprite musicOnSprite;
    [SerializeField]
    private Sprite musicOffSprite;

    [SerializeField]
    private Button soundButton;
    [SerializeField]
    private Image soundImage;
    [SerializeField]
    private Sprite soundOnSprite;
    [SerializeField]
    private Sprite soundOffSprite;

    [SerializeField]
    private Text highScoreText;

    private void Start()
    {
        SetHighScoreText();
    }

    private void SetHighScoreText()
    {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore");

        SetSprites();

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
            });
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 1)
                {
                    AudioManager.instance.OffMusic();
                }
                else
                {
                    AudioManager.instance.OnMusic();
                }

                SetSprites();
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 1)
                {
                    AudioManager.instance.OffSound();
                }
                else
                {
                    AudioManager.instance.OnSound();
                }

                SetSprites();
            });
        }
    }

    private void SetSprites()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 1)
        {
            musicImage.sprite = musicOnSprite;
        }
        else if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        {
            musicImage.sprite = musicOffSprite;
        }

        if (PlayerPrefs.GetFloat("SoundVolume") == 1)
        {
            soundImage.sprite = soundOnSprite;
        }
        else if (PlayerPrefs.GetFloat("SoundVolume") == 0)
        {
            soundImage.sprite = soundOffSprite;
        }
    }
}
