using System;

public abstract class FileStorage
{
    public abstract void Upload(string filename);

    public void validateFile()
    {
        Console.WriteLine("Validating file........");
    }
}