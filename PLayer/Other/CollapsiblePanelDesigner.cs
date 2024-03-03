using System;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

namespace STM.PLayer.Other
{
    public class CollapsiblePanelDesigner : ParentControlDesigner
    {

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                var collection = new DesignerActionListCollection();
                if (Control != null && Control is CollapsiblePanel.CollapsiblePanel)
                {
                    var panel = (CollapsiblePanel.CollapsiblePanel)Control;
                    if (!String.IsNullOrEmpty(panel.Name))
                    {
                        if (String.IsNullOrEmpty(panel.HeaderText))
                            panel.HeaderText = panel.Name;
                    }
                }

                collection.Add(new CollapsiblePanelActionList(Control));
                
                return collection;
            }
        }

       


        
    }
}
