Imports System.Data.Entity

Namespace XtraSchedulerEFTest

'#Region "#schedulercontext"
    Friend Class SchedulerContext
        Inherits DbContext

        Public Property EFAppointments As DbSet(Of EFAppointment)

        Public Property EFResources As DbSet(Of EFResource)
    End Class

'#End Region  ' #schedulercontext
    Friend Class SchedulerContextSeedInilializer
        Inherits DropCreateDatabaseIfModelChanges(Of SchedulerContext)

        Protected Overrides Sub Seed(ByVal context As SchedulerContext)
            Dim res1 As EFResource = New EFResource()
            res1.ResourceID = 1
            res1.ResourceName = "Resource1"
            context.EFResources.Add(res1)
            res1.Color = System.Drawing.Color.DarkOrange.ToArgb()
            Dim res2 As EFResource = New EFResource()
            res2.ResourceID = 2
            res2.ResourceName = "Resource2"
            res2.Color = System.Drawing.Color.SteelBlue.ToArgb()
            context.EFResources.Add(res2)
            context.SaveChanges()
        End Sub
    End Class
End Namespace
