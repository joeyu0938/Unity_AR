using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Net;
using UnityEngine.Networking;
using System.Collections;
using System.Threading;
// �i��ܷӤ��W�Ǧ�flask�ҫ��w����Ƨ�(�ثe���|:UPLOAD_FOLDER = 'C://a/c')
public class ImageUpload : MonoBehaviour
{

    public Texture2D texture;
    public Texture2D image;
    public string url = "http://120.126.151.82:5000/uploader";
    [Obsolete]
    void Start()
    {
        texture = new Texture2D(2, 2); // ��l�Ư��z
    }
    //Download

    public void OnOpenGalleryButtonClicked()
    {
        // ���}�Ϥ���ܾ�

        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {

            if (path != null)
            {
                byte[] fileData = File.ReadAllBytes(path);
                // Create a form to send the file data to the server
                WWWForm form = new WWWForm();
                form.AddBinaryData("file", fileData, "upload.jpg");
                Debug.Log("Upload");
                // Send the form data to the server
                UnityWebRequest www = UnityWebRequest.Post(url, form);
                www.SendWebRequest();
            }
        }, "Select an image", "image/*");
        
        SceneManager.LoadScene(1);
    }


}