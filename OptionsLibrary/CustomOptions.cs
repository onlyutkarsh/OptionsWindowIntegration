using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace OptionsLibrary
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid("FE594AA2-0C82-481A-99DE-E99343ECEA0B")]
    public class CustomOptions : DialogPage
    {
        private CustomOptionsControl _optionsControl;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PathForVisualStudio { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override System.Windows.Forms.IWin32Window Window
        {
            get
            {
                _optionsControl = new CustomOptionsControl();
                _optionsControl.OptionsPage = this;
                _optionsControl.TextBoxValue = PathForVisualStudio;
                return _optionsControl;
            }
        }

        protected override void OnApply(DialogPage.PageApplyEventArgs e)
        {
            if (e.ApplyBehavior == ApplyKind.Apply)
            {
                PathForVisualStudio = _optionsControl.TextBoxValue;
            }
            base.OnApply(e);
        }

    }
}