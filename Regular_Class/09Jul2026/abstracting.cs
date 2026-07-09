using System;

public class abstracting : FileStorage
{
    public override void Upload(string filename)
    {
        Console.WriteLine("Uploading File:" + filename);
    }
}