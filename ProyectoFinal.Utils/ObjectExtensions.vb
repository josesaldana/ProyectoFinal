Imports System.Runtime.CompilerServices
Imports Newtonsoft.Json

Public Module ObjectExtensions
    <Extension()>
    Public Function DeepCopy(Of T)(self As T) As T
        Dim serialized = JsonConvert.SerializeObject(self)
        Return JsonConvert.DeserializeObject(Of T)(serialized)
    End Function
End Module
