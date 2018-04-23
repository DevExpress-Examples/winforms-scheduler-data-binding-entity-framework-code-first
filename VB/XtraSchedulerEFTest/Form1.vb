Imports System
Imports System.Data.Entity
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace XtraSchedulerEFTest
    Partial Public Class Form1
        Inherits Form

        Private context As SchedulerContext
        Public Sub New()
            InitializeComponent()

            schedulerStorage1.Appointments.CommitIdToDataSource = False
            schedulerStorage1.Appointments.ResourceSharing = True
            schedulerControl1.Storage.Resources.ColorSaving = ColorSavingType.ArgbColor

            '            #Region "#appmappings"
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.AppointmentId = "UniqueID"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.End = "EndDate"
            Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            Me.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceIDs"
            Me.schedulerStorage1.Appointments.Mappings.Start = "StartDate"
            Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerStorage1.Appointments.Mappings.Type = "Type"
            '            #End Region ' #appmappings
            '            #Region "#resmappings"
            Me.schedulerStorage1.Resources.Mappings.Caption = "ResourceName"
            Me.schedulerStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerStorage1.Resources.Mappings.Id = "ResourceID"
            Me.schedulerStorage1.Resources.Mappings.Image = "Image"
            '            #End Region ' #resmappings 

            AddHandler schedulerControl1.Storage.AppointmentsChanged, AddressOf Storage_AppointmentsModified
            AddHandler schedulerControl1.Storage.AppointmentsInserted, AddressOf Storage_AppointmentsModified
            AddHandler schedulerControl1.Storage.AppointmentsDeleted, AddressOf Storage_AppointmentsModified

            schedulerControl1.GroupType = SchedulerGroupType.Resource
            schedulerControl1.Start = Date.Now.Date
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            '            #Region "#datainit"
            Database.SetInitializer(New SchedulerContextSeedInilializer())
            context = New SchedulerContext()

            context.Database.Initialize(False)
            context.EFAppointments.Load()
            context.EFResources.Load()

            eFAppointmentBindingSource.DataSource = context.EFAppointments.Local.ToBindingList()
            eFResourceBindingSource.DataSource = context.EFResources.Local.ToBindingList()
            '            #End Region ' #datainit

        End Sub

        Private Sub Storage_AppointmentsModified(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs)
            context.SaveChanges()
        End Sub

        Private Sub btnCreateAppointment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateAppointment.Click
            Dim apt As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
            apt.Start = Date.Now
            apt.End = Date.Now.AddHours(4)
            apt.Subject = "Created in code"
            apt.LabelKey = 5
            schedulerStorage1.Appointments.Add(apt)
        End Sub
    End Class
End Namespace
