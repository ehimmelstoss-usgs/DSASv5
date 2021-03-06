''' <summary>
''' CI class is used to provide items for display as confidence intervals.
''' This way a CI item can have a value that is different than the string used to describe it.
''' </summary>
''' <remarks></remarks>
Public Class CI
    Private value_ As Decimal
    Private Shared CIs As New Hashtable

    Sub New(ByVal value As Decimal)
        value_ = value
        If Not CIs.ContainsKey(value_) Then CIs.Add(value_, Me)
    End Sub

    Public ReadOnly Property displayName() As String
        Get
            Return String.Format("{0}%", value_)
        End Get
    End Property

    Public ReadOnly Property fieldNameCompatible() As String
        Get
            Return String.Format("{0}", value_).Replace(".", "_")
        End Get
    End Property

    Public ReadOnly Property itemValue() As Decimal
        Get
            Return value_
        End Get
    End Property

    Shared Function getCIFor(ByVal value As Decimal) As CI
        If Not CIs.ContainsKey(value) Then
            Dim dummy = New CI(value)
        End If
        Return CIs(value)
    End Function

End Class
