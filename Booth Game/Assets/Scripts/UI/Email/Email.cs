using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(fileName="New Email", menuName="Create Email")]
public class Email : ScriptableObject
{
    public string subject;
    public string username;
    public string email;
    [TextArea(10, 100)] public string content;
    public bool isPhishing;

    public string message
    {
        get
        {
            string pattern = @"\[([^]]+)\]\(([^)]+)\)";

            return Regex.Replace(content, pattern, match =>
            {
                string text = match.Groups[1].Value;
                string url = match.Groups[2].Value;

                return $"<link=\"{url}\"><color=#417ee8ff>{text}</color></link>";
            });
        }
    }
}
