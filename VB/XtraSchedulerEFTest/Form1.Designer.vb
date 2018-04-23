Imports Microsoft.VisualBasic
Imports System
Namespace XtraSchedulerEFTest
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
			Me.eFAppointmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.eFResourceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.btnCreateAppointment = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.eFAppointmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.eFResourceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' schedulerControl1
			' 
			Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.schedulerControl1.Location = New System.Drawing.Point(0, 44)
			Me.schedulerControl1.Name = "schedulerControl1"
			Me.schedulerControl1.Size = New System.Drawing.Size(776, 466)
			Me.schedulerControl1.Start = New System.DateTime(1753, 1, 1, 0, 0, 0, 0)
			Me.schedulerControl1.Storage = Me.schedulerStorage1
			Me.schedulerControl1.TabIndex = 0
			Me.schedulerControl1.Text = "schedulerControl1"
			Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
			' 
			' schedulerStorage1
			' 
			Me.schedulerStorage1.Appointments.DataSource = Me.eFAppointmentBindingSource
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
			Me.schedulerStorage1.Appointments.ResourceSharing = True
			Me.schedulerStorage1.Resources.DataSource = Me.eFResourceBindingSource
			Me.schedulerStorage1.Resources.Mappings.Caption = "ResourceName"
			Me.schedulerStorage1.Resources.Mappings.Color = "Color"
			Me.schedulerStorage1.Resources.Mappings.Id = "ResourceID"
			Me.schedulerStorage1.Resources.Mappings.Image = "Image"
			' 
			' eFAppointmentBindingSource
			' 
			Me.eFAppointmentBindingSource.DataSource = GetType(XtraSchedulerEFTest.EFAppointment)
			' 
			' eFResourceBindingSource
			' 
			Me.eFResourceBindingSource.DataSource = GetType(XtraSchedulerEFTest.EFResource)
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.btnCreateAppointment)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(776, 44)
			Me.panelControl1.TabIndex = 1
			' 
			' btnCreateAppointment
			' 
			Me.btnCreateAppointment.Location = New System.Drawing.Point(12, 12)
			Me.btnCreateAppointment.Name = "btnCreateAppointment"
			Me.btnCreateAppointment.Size = New System.Drawing.Size(116, 23)
			Me.btnCreateAppointment.TabIndex = 0
			Me.btnCreateAppointment.Text = "Create Appointment"
'			Me.btnCreateAppointment.Click += New System.EventHandler(Me.btnCreateAppointment_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(776, 510)
			Me.Controls.Add(Me.schedulerControl1)
			Me.Controls.Add(Me.panelControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.eFAppointmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.eFResourceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private WithEvents btnCreateAppointment As DevExpress.XtraEditors.SimpleButton
		Private eFAppointmentBindingSource As System.Windows.Forms.BindingSource
		Private eFResourceBindingSource As System.Windows.Forms.BindingSource
	End Class
End Namespace

