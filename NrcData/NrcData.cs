using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace UCSPyayStudentRegistration.NrcData {
 public static class NrcTownshipData { static readonly Dictionary<int,string[]> Data=new Dictionary<int,string[]> { {7,new[]{"PaMaNa","PaTaSa","YaKaNa","YaTaNa","TaNgaNa","ThaNaPa","ThaKaNa"}}, {11,new[]{"SaTaNa","MaPaNa","YaBaNa","KaTaNa"}}, {12,new[]{"LaMaNa","KaMaYa","BaHaNa","DaGaNa","TaMaNa"}}, {1,new[]{"MaKaNa","WaMaNa","BaMaNa"}}, {2,new[]{"LaKaNa","DaMaSa","PhaSaNa"}}, {3,new[]{"BaGaLa","KaKaYa","PaKaNa"}}, {4,new[]{"HaKhaNa","PhaLaNa","TaTaNa"}}, {5,new[]{"SaKaNa","MaYaNa","KaLaNa"}}, {6,new[]{"HtaWaNa","LaLaNa","KaThaNa"}}, {8,new[]{"MaKaNa","PaKhaKa","SaLaNa"}}, {9,new[]{"MaHaMa","PaBaNa","AmZaTa"}}, {10,new[]{"MaLaMa","ThaHtaNa","KhaSaNa"}}, {13,new[]{"TaKaNa","LaYaNa","MaSaNa"}}, {14,new[]{"PaThaNa","MaMaNa","DaDaYa"}} };
  public static IEnumerable<int> Regions { get { return Data.Keys; } } public static string[] ForRegion(int n){return Data.ContainsKey(n)?Data[n]:new string[0];}
 }
 public static class NrcValidation { public static bool IsValid(int region,string township,string type,string serial){ if(!Regex.IsMatch(serial??"", "^[0-9]{6}$")||!Regex.IsMatch(type??"","^[NEPTYS]$")) return false; foreach(var t in NrcTownshipData.ForRegion(region)) if(t==township)return true; return false;} public static string Format(int r,string t,string type,string s){return r+"/"+t+"("+type+")"+s;} }
}
