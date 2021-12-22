// Create a new 'HttpWebRequest' object to the mentioned URL.

using System.Net;

HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.kabum.com.br/?");
myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
// Display the contents of the page to the console.
Stream streamResponse = myHttpWebResponse.GetResponseStream();
StreamReader streamRead = new StreamReader(streamResponse);
Char[] readBuff = new Char[256];
int count = streamRead.Read(readBuff, 0, 256);
Console.WriteLine("\nThe contents of HTML Page are :\n");
while (count > 0)
{
    String outputData = new String(readBuff, 0, count);
    Console.Write(outputData);
    count = streamRead.Read(readBuff, 0, 256);
}
// Release the response object resources.
streamRead.Close();
streamResponse.Close();
myHttpWebResponse.Close();