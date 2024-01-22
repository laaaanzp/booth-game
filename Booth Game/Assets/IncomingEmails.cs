using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class IncomingEmails : MonoBehaviour
{
    [SerializeField] private GameObject emailRadioButtonPrefab;
    [SerializeField] private Transform emailRadioButtonsContainer;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Image takeDamageImage;
    [SerializeField] private TextMeshProUGUI lifeText;

    [SerializeField] private int life = 3;
    private int maxLife;


    void Awake()
    {
        maxLife = life;
        lifeText.text = $"Mistakes: {maxLife - life}/{maxLife}";
        Email[] emails = Resources.LoadAll<Email>("Emails");


        for (int i = 0; i < emails.Length - 1; ++i)
        {
            int r = Random.Range(i, emails.Length);
            (emails[r], emails[i]) = (emails[i], emails[r]);
        }

        foreach (Email email in emails)
        {
            GameObject emailRadioButtonObjec = Instantiate(emailRadioButtonPrefab, emailRadioButtonsContainer);
            RadioButton radioButton = emailRadioButtonObjec.GetComponent<RadioButton>();
            radioButton.Initialize(email);
        }
    }

    public void DeleteEmail()
    {
        if (RadioButton.selected == null) return;

        Email email = RadioButton.selected.email;

        if (!email.isPhishing) OnLifeDeduction();
        if (life == 0) OnGameOver();

        Destroy(RadioButton.selected.gameObject);
        EmailPreview.Close();

        if (emailRadioButtonsContainer.childCount == 1) OnLevelFinish(); // For some reason, childCount doesn't update on the same frame
    }

    public void SaveEmail()
    {
        if (RadioButton.selected == null) return;

        Email email = RadioButton.selected.email;

        if (email.isPhishing) OnLifeDeduction();
        if (life == 0) OnGameOver();

        Destroy(RadioButton.selected.gameObject);
        EmailPreview.Close();

        if (emailRadioButtonsContainer.childCount == 1) OnLevelFinish(); // For some reason, childCount doesn't update on the same frame
    }

    public void OnLevelFinish()
    {
        if (life == 0) return;

        string message = "";

        if (life == maxLife)
            message = "Well done. You have cleaned the incoming emails with no mistake.";

        else if (life == maxLife - 1)
            message = "Well done, you have cleaned the incoming mails with a single mistake.";

        else
            message = $"Well done, you have cleaned the incoming mails with {maxLife - life} mistake(s).";

        MessageBoxControl.Open("Level Complete", message, MessageBoxButtons.OK, () => { SceneManager.LoadScene(0); });
    }

    public void OnLifeDeduction()
    {
        life--;
        lifeText.text = $"Mistakes: {maxLife - life}/{maxLife}";
        LeanTween.alpha(takeDamageImage.rectTransform, 1f, 0f).setOnComplete(() =>
        {
            LeanTween.alpha(takeDamageImage.rectTransform, 0f, 3f).setEaseOutQuint();
        });
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
