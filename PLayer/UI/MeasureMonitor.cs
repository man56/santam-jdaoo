using System;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer;
using STM.Properties;

namespace STM.PLayer.UI
{
    public partial class MeasureMonitor : UserControl
    { 
        public MeasureType MeasureType { set; get; }
        public string MeasureName
        {
            set
            {
                lbName.Text = value;
            }
        }
       
        
        public string ValueInString
        {
            set
            {
                lbMeasure.Text = value;
            }
        }
        public string Unit { private set; get; }
        public string ToolName { set; get; }
        public int Order { set; get; }
        public string Label { set; get; }

        private ContextMenuStrip menuUints;
        private ContextMenuStrip menuMeasureSetting;

         
        public MeasureMonitor()
        {
            InitializeComponent();
        }

        public MeasureMonitor(MeasureType type, string tool = "", string label="")
        {
            InitializeComponent();
            MeasureType = type;
            ToolName = tool;
            Label = label;
            bttnZero.Visible = type != MeasureType.Time;
        }

        private void MeasureMonitor_Load(object sender, EventArgs e)
        {
            lbName.Text = string.IsNullOrEmpty(Label) ? MeasureTool.MeasureToolLabels[MeasureType] : string.Format("{0}({1})", Label, ToolName.Split("()".ToCharArray())[1]);
            lbMeasure.Text = @"---";
            lbUnit.Text = @"---";
            LoadMeasureTypeMenu();
            LoadUnitMenu();
        }
        
        private void LoadMeasureTypeMenu()
        {
            menuMeasureSetting = new ContextMenuStrip();
            var names = MeasureTool.MeasureToolLabels.Values.ToList();
            foreach (var tsm in names.Select(item => new ToolStripMenuItem(item) {Name = item}))
            {
                menuMeasureSetting.Items.Add(tsm);
                tsm.Checked = false;
                tsm.Checked = tsm.Text == MeasureTool.MeasureToolLabels[MeasureType];
            }
             
            foreach (ToolStripItem item in menuMeasureSetting.Items)
            {
                item.Click += menuMeasureSetting_Click;
            }
             
            var remove = new ToolStripMenuItem(Resources.MeasureMonitor_LoadMeasureTypeMenu_Remove);
            remove.Click += (sender, e) => DelMeasure();
            menuMeasureSetting.Items.Add(remove);
        }

        public void LoadUnitMenu()
        {
            var selected = "";
            var items = MeasureTool.Units(MeasureType, out selected);

            menuUints = new ContextMenuStrip();
            foreach (var item in items.Select(p=>new ToolStripMenuItem(UnitManager.TranslateUnitTitle(p)) {Name = p, Checked = selected.Equals(p)}))
            {
                item.Click += menuUnits_Click;
                menuUints.Items.Add(item);
            }
            menuUints.Items.Add(new ToolStripSeparator());
            var unitSystems = new ToolStripMenuItem(Resources.MeasureMonitor_LoadUnitMenu_Unit_Systems) {Name = "menuUnitSystem" };
            unitSystems.Click += menuUnitSystems_Click;
            menuUints.Items.Add(unitSystems);

            Unit = selected ?? "";
			lbUnit.Text = UnitManager.TranslateUnitTitle(Unit);
        }

        private void lbUnit_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && menuUints != null)
            {
                menuUints.Show(lbUnit, e.Location);
            }
        }
         
        private void lbName_MouseClick(object sender, MouseEventArgs e)
        {
            menuMeasureSetting.Show(lbName, e.Location);
        }

        private void menuMeasureSetting_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in menuMeasureSetting.Items)
            {
                item.Checked = false;
            }
            var menu = sender as ToolStripMenuItem;
            menu.Checked = true;
            MeasureType = MeasureTool.GetToolMeasureType(menu.Text);
            bttnZero.Visible = MeasureType != MeasureType.Time;
            MeasurementMonitors.MeasureTools[Order] = new MeasureTool
            {
                MeasureLable = "",
                MeasureType = MeasureType,
                Order = Order
            };

            MeasureName = menu.Text;
            LoadUnitMenu();
        }


        private void DelMeasure()
        {
            if (OnMeasureDelete != null)
                OnMeasureDelete(this, EventArgs.Empty);
        }

        public void UpdateUnit(string unit)
        {
            foreach (var menu in menuUints.Items)
            {
                if(menu is ToolStripSeparator)
                    continue;
                var m = menu as ToolStripMenuItem;
                m.Checked = m.Name.Equals(unit);
                if (!m.Checked) continue;
                Unit = m.Name;
                lbUnit.Text = UnitManager.TranslateUnitTitle(Unit);
            }
        }

        private void menuUnits_Click(object sender, EventArgs e)
        {
            var senderMenu = sender as ToolStripMenuItem;
            if (senderMenu != null && senderMenu.Checked == false)

                foreach (var menu in menuUints.Items)
                {
                    var menuItem = menu as ToolStripMenuItem;
                    if (menuItem != null) menuItem.Checked = false;
                }
            OnUnitChanges?.Invoke(this, new UnitChangeEventArgs {measureType = MeasureType, Unit = senderMenu?.Name});
        }

        private void menuUnitSystems_Click(object sender, EventArgs e)
        {
            OnUnitSystem?.Invoke(this,EventArgs.Empty);
        }

        private void bttnZero_Click(object sender, EventArgs e)
        {
            OnZero?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<UnitChangeEventArgs> OnUnitChanges;
        public event EventHandler<EventArgs> OnUnitSystem;
        public event EventHandler<EventArgs> OnMeasureDelete;
        public event EventHandler<EventArgs> OnZero;


        public void Freeze()
        {
            bttnZero.Enabled = false;
        }

        public void UnFreeze()
        {
            bttnZero.Enabled = true;
        }
    }
}

