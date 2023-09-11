Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Drawing

Namespace XtraSchedulerEFTest

'#Region "#efresource"
    Friend Class EFResource

        <Key>
        Public Property UniqueID As Integer

        Public Property ResourceID As Integer

        Public Property ResourceName As String

        Public Property Image As Byte()

        Public Property Color As Integer
            Get
                Return ColorEx.ToArgb()
            End Get

            Set(ByVal value As Integer)
                ColorEx = New MyColor(value)
            End Set
        End Property

        Public Property ColorEx As MyColor
    End Class

    Friend Class MyColor

        Public Property A As Byte

        Public Property R As Byte

        Public Property G As Byte

        Public Property B As Byte

        Public Sub New()
        End Sub

        Public Sub New(ByVal a As Byte, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
            Me.A = a
            Me.R = r
            Me.G = g
            Me.B = b
        End Sub

        Public Sub New(ByVal color As Color)
            A = color.A
            R = color.R
            G = color.G
            B = color.B
        End Sub

        Public Sub New(ByVal argb As Integer)
            Dim bytes As Byte() = BitConverter.GetBytes(argb)
            A = bytes(0)
            R = bytes(1)
            G = bytes(2)
            B = bytes(3)
        End Sub

        Public Function ToColor() As Color
            Return Color.FromArgb(A, R, G, B)
        End Function

        Public Shared Function FromColor(ByVal color As Color) As MyColor
            Return New MyColor(color.A, color.R, color.G, color.B)
        End Function

        Public Function ToArgb() As Integer
            Dim bytes As Byte() = New Byte() {A, R, G, B}
            Return BitConverter.ToInt32(bytes, 0)
        End Function
    End Class
'#End Region  ' #efresource
End Namespace
