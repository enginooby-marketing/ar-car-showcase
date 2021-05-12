using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine.Networking;
using UnityEngine.Video;
using TMPro;

public partial class Wit3D : MonoBehaviour
{
    // audio & clip parameters
    AudioClip commandClip;
    string commandClipName;
    int frequency;
    int lengthSec;
    bool isRecording = false;


    // Wit API parameters
    [SerializeField] string url;
    [SerializeField] string token;
    Dictionary<string, string> header;

    public TextMeshProUGUI resultLabel;
    // public VideoPlayer vidScreen;
    // public GameObject vidCanvas;

    void Start()
    {
        commandClipName = "Command clip";
        frequency = 16000;
        lengthSec = 5;
        header = GenerateWitRequestHeader(token);
        // vidScreen.GetComponent<VideoPlayer>();
    }

    public void ToggleRecording()
    {
        isRecording = !isRecording;

        // start recording when press button
        if (isRecording)
        {
            resultLabel.text = "Listening for command...";
            commandClip = Microphone.Start(null, false, lengthSec, frequency);
        }
        // stop recording when press button
        else
        {
            resultLabel.text = "Saving voice request...";
            SaveAudio();
            StartCoroutine(SendWitRequest());
        }
    }

    private void SaveAudio()
    {
        Microphone.End(null);
        if (WavSaver.Save(commandClipName, commandClip))
        {
            resultLabel.text = "Sending audio to AI...";
        }
        else
        {
            resultLabel.text = "Failed to save audio";
        }
        // At this point, we can delete the existing audio clip
        commandClip = null;
    }
    public void PlayVideo()
    {
        // vidScreen.Play();
        // vidCanvas.SetActive(false);
    }
    public void StopVideo()
    {
        // vidScreen.Stop();
        // vidCanvas.SetActive(true);
    }

    public IEnumerator SendWitRequest()
    {
        string commandClipPath = Application.persistentDataPath + "/" + commandClipName + ".wav";
        byte[] postData = FileToBinary(commandClipPath);

        float timeSent = Time.time;
        WWW www = new WWW(url, postData, header);
        yield return www;

        while (!www.isDone)
        {
            resultLabel.text = "Thinking and deciding ...";
            yield return null;
        }
        float duration = Time.time - timeSent;

        if (www.error != null && www.error.Length > 0)
        {
            UnityEngine.Debug.Log("Error: " + www.error + " (" + duration + " secs)");
            yield break;
        }
        Debug.Log("Success (" + duration + " secs)");
        Debug.Log("Result: " + www.text);

        HandleWitResponse(www.text);
    }

    private Dictionary<string, string> GenerateWitRequestHeader(string token)
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers["Content-Type"] = "audio/wav";
        headers["Authorization"] = "Bearer " + token;

        return headers;
    }

    private byte[] FileToBinary(string filePath)
    {
        FileStream filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        BinaryReader filereader = new BinaryReader(filestream);
        byte[] data = filereader.ReadBytes((Int32)filestream.Length);
        filestream.Close();
        filereader.Close();

        return data;
    }
}