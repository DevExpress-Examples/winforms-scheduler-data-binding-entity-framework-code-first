using System;
using System.Data.Entity;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace XtraSchedulerEFTest
{
    public partial class Form1 : Form
    {
        private SchedulerContext context;
        public Form1()
        {
            InitializeComponent();

            schedulerStorage1.Appointments.ResourceSharing = true;
            schedulerControl1.DataStorage.Resources.ColorSaving = ColorSavingType.ArgbColor;

            #region #appmappings
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.AppointmentId = "UniqueID";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceIDs";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "Type";
            #endregion #appmappings
            #region #resmappings
            this.schedulerStorage1.Resources.Mappings.Caption = "ResourceName";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "ResourceID";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
            #endregion #resmappings 

            schedulerControl1.DataStorage.AppointmentsChanged += Storage_AppointmentsModified;
            schedulerControl1.DataStorage.AppointmentsInserted += Storage_AppointmentsModified;
            schedulerControl1.DataStorage.AppointmentsDeleted += Storage_AppointmentsModified;

            schedulerControl1.GroupType = SchedulerGroupType.Resource;            
            schedulerControl1.Start = DateTime.Now.Date;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region #datainit
            Database.SetInitializer(new SchedulerContextSeedInilializer());
            context = new SchedulerContext();

            context.Database.Initialize(false);
            context.EFAppointments.Load();
            context.EFResources.Load();

            eFAppointmentBindingSource.DataSource = context.EFAppointments.Local.ToBindingList<EFAppointment>();
            eFResourceBindingSource.DataSource = context.EFResources.Local.ToBindingList<EFResource>();
            #endregion #datainit

        }

        void Storage_AppointmentsModified(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            context.SaveChanges();
        }

        private void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            Appointment apt  = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
            apt.Start = DateTime.Now;
            apt.End = DateTime.Now.AddHours(4);
            apt.Subject = "Created in code";
            apt.LabelKey = 5;
            schedulerStorage1.Appointments.Add(apt);
        }
    }
}
