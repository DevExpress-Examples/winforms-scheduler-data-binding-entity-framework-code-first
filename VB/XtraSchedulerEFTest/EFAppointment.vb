Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace XtraSchedulerEFTest

'#Region "#efappointment"
    Friend Class EFAppointment

        <Key>
        Public Property UniqueID As Integer

        <Required>
        Public Property Type As Integer

        <Required>
        Public Property StartDate As Date

        <Required>
        Public Property EndDate As Date

        Public Property AllDay As Boolean

        Public Property Subject As String

        Public Property Location As String

        Public Property Description As String

        Public Property Status As Integer

        Public Property Label As Integer

        Public Property ResourceIDs As String

        Public Property ReminderInfo As String

        Public Property RecurrenceInfo As String
    End Class
'#End Region  ' #efappointment
End Namespace
