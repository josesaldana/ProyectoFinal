Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices

Public Module SpecializedCollectionExtension
    'KeysCollection
    <Extension()>
    Public Function ToList(keys As NameObjectCollectionBase.KeysCollection) As List(Of String)
        Dim keysList = New List(Of String)
        For Each key In keys
            keysList.Add(key)
        Next
        Return keysList
    End Function
End Module
