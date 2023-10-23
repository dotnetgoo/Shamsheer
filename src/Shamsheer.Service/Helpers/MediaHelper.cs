using System.IO;
using System;

namespace Shamsheer.Service.Helpers;

public class MediaHelper
{
    public static string IMAGE = "Images";
    public static string FILE = "Files";
    public static string AUDIO = "Audios";
    public static string VIDEO = "Videos";
    public static string MakeImageName(string filename, string filePath)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "";
        if (filePath == IMAGE)
            name = "IMG_" + Guid.NewGuid() + extension;
        else if (filePath == FILE)
            name = "FILE_" + Guid.NewGuid() + extension;
        else if (filePath == AUDIO)
            name = "AUDIO_" + Guid.NewGuid() + extension;
        else if (filePath == VIDEO)
            name = "VIDEO_" + Guid.NewGuid() + extension;
        return name;
    }
    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".heic"
        };
    }
}