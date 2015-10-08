using UnityEngine;
using System.Collections;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using System; //Exception
using System.Text; //Encoding

public class TextStreamer : SingletonMono<TextStreamer> {
  private string outputFileName;

  // Use this for initialization
  public void Initialize() {
    string txt = Application.dataPath;
    outputFileName = "result_";
    outputFileName += this.retFixTimeStr(DateTime.Now.Hour);
    outputFileName += this.retFixTimeStr(DateTime.Now.Minute);
    outputFileName += this.retFixTimeStr(DateTime.Now.Second);
    outputFileName += ".txt";
  }

  private string retFixTimeStr(int t) {
    if(t < 10) { return "0" + t; }
    else { return "" + t; }
  }

  public void WriteFile(string txt) {
    FileInfo fi = new FileInfo(Application.dataPath + "/" + outputFileName);
    using (StreamWriter sw = fi.AppendText()) {
      sw.WriteLine(txt);
    }
  }

  // Update is called once per frame
  void Update() {

  }
}
