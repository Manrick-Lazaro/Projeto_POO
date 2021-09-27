using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Arquivo<T> {
  public T Abrir (string arquivo) {
    StreamReader x = new StreamReader(arquivo, Encoding.Default);
    XmlSerializer xml = new XmlSerializer (typeof(T));
    T obj = (T)xml.Deserialize(x);
    x.Close();
    return obj;
  }
  public void Salvar(string arquivo, T obj) {
      StreamWriter x  = new StreamWriter (arquivo, false, Encoding.Default);
      XmlSerializer xml = new XmlSerializer(typeof(T));
      xml.Serialize(x, obj);
      x.Close();
  }
}