Imports System
Imports System.Data.Entity
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace XtraSchedulerEFTest

    Public Partial Class Form1
        Inherits Form

        Private context As SchedulerContext

        Public Sub New()
            InitializeComponent()
            schedulerStorage1.Appointments.CommitIdToDataSource = False
            schedulerStorage1.Appointments.ResourceSharing = True
            schedulerControl1.Storage.Resources.ColorSaving = ColorSavingType.ArgbColor
'#Region "#appmappings"
            schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            schedulerStorage1.Appointments.Mappings.AppointmentId = "UniqueID"
            schedulerStorage1.Appointments.Mappings.Description = "Description"
            schedulerStorage1.Appointments.Mappings.End = "EndDate"
            schedulerStorage1.Appointments.Mappings.Label = "Label"
            schedulerStorage1.Appointments.Mappings.Location = "Location"
            schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceIDs"
            schedulerStorage1.Appointments.Mappings.Start = "StartDate"
            schedulerStorage1.Appointments.Mappings.Status = "Status"
            schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            schedulerStorage1.Appointments.Mappings.Type = "Type"
'#End Region  ' #appmappings
'#Region "#resmappings"
            schedulerStorage1.Resources.Mappings.Caption = "ResourceName"
            schedulerStorage1.Resources.Mappings.Color = "Color"
            schedulerStorage1.Resources.Mappings.Id = "ResourceID"
            schedulerStorage1.Resources.Mappings.Image = "Image"
'#End Region  ' #resmappings 
            AddHandler schedulerControl1.Storage.AppointmentsChanged, AddressOf Storage_AppointmentsModified
            AddHandler schedulerControl1.Storage.AppointmentsInserted, AddressOf Storage_AppointmentsModified
            AddHandler schedulerControl1.Storage.AppointmentsDeleted, AddressOf Storage_AppointmentsModified
            schedulerControl1.GroupType = SchedulerGroupType.Resource
            schedulerControl1.Start = Date.Now.Date
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
'#Region "#datainit"
            Call Database.SetInitializer(New SchedulerContextSeedInilializer())
            context = New SchedulerContext()
            context.Database.Initialize(False)
            context.EFAppointments.Load()
            context.EFResources.Load()
            eFAppointmentBindingSource.DataSource = context.EFAppointments.Local.ToBindingList(Of EFAppointment)()
            eFResourceBindingSource.DataSource = context.EFResources.Local.ToBindingList(Of EFResource)()
'#End Region  ' #datainit
        End Sub

        Private Sub Storage_AppointmentsModified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            context.SaveChanges()
        End Sub

        Private Sub btnCreateAppointment_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim apt As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
            apt.Start = Date.Now
            apt.End = Date.Now.AddHours(4)
            apt.Subject = "Created in code"
            apt.LabelKey = 5
            schedulerStorage1.Appointments.Add(apt)
        End Sub
    End Class
End Namespace
