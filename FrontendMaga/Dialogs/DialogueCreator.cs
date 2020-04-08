using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrontendMaga.Dialogs
{
    public enum DialogDataType
    {
        Text,
        Float,
        Integer

    }
    public partial class DialogueCreator : Form
    {

        private List<Control> _controls = new List<Control>();
        private event Action<DialogueEventArgs> _onSubmit;

        public DialogueCreator(Action<DialogueEventArgs> onSubmit)
        {
            _onSubmit += onSubmit;
            InitializeComponent();
        }

        private void DialogueCreator_Load(object sender, EventArgs e)
        {

        }



        public void AddControl(string controlName,string labelText,Type controlType,string text = null)
        {
            var control = (Control) Activator.CreateInstance(controlType);
            Controls.Add(control);
            control.Name = controlName;
            container.RowCount++;
            container.Controls.Add(control, 1, container.RowCount - 2);
            control.Dock = DockStyle.Fill;
            var label = new Label();
            label.Text = labelText;
            container.Controls.Add(label, 0, container.RowCount - 2);
            label.Dock = DockStyle.Fill;
            Height += 50;
            _controls.Add(control);
            control.Text = text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var args = InitArgs();
            _onSubmit(args);
            Close();
        }

        private DialogueEventArgs InitArgs()
        {
            var res = new DialogueEventArgs();
            foreach(var c in _controls)
            {
                res.DialogArgs.Add(c.Name, c.Text);
            }

            return res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class DialogueEventArgs
    {
        public Dictionary<string, string> DialogArgs = new Dictionary<string, string>();

        public string GetValue(string key)
        {
            string value;
            DialogArgs.TryGetValue(key, out value);
            if (value.Trim().ToLower() == "") value = null;
            return value;
        }
    }
    public abstract class DialogControl
    {
        public bool NotNull { get; set; }
        private DialogDataType _dataType = DialogDataType.Text;
        public string ControlName { get; set; }

        
    
    }
}
