using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;

namespace STM.PLayer.Other
{
    public class CollapsiblePanelActionList : DesignerActionList
    {
        public CollapsiblePanelActionList(IComponent component)
            : base(component)
        {

        }

        public string Title
        {
            get
            {
                return ((CollapsiblePanel.CollapsiblePanel)this.Component).HeaderText;
            }
            set
            {
                var property =  TypeDescriptor.GetProperties(Component)["HeaderText"];
                property.SetValue(this.Component, value);

            }
        }

        public bool Collapsed
        {
            get
            {
                return ((CollapsiblePanel.CollapsiblePanel)this.Component).Collapse;
            }
            set
            {
                var property = TypeDescriptor.GetProperties(this.Component)["Collapse"];
                property.SetValue(Component, value);

            }
        }

        public int HeaderCornersRadius
        {
            get
            {
                return ((CollapsiblePanel.CollapsiblePanel)Component).HeaderCornersRadius;
            }
            set
            {
                var property = TypeDescriptor.GetProperties(Component)["HeaderCornersRadius"];
                property.SetValue(this.Component, value);
            }
        }



        public Image HeaderImage
        {
            get
            {
                return ((CollapsiblePanel.CollapsiblePanel)this.Component).HeaderImage;
            }
            set
            {
                var property = TypeDescriptor.GetProperties(Component)["HeaderImage"];
                property.SetValue(Component, value);
            }
        }



        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection
                                                     {
                                                         new DesignerActionHeaderItem("Header Parameters"),
                                                         new DesignerActionPropertyItem("Title", "Panel's header text"),
                                                         new DesignerActionPropertyItem("HeaderImage", "Image"),
                                                         new DesignerActionPropertyItem("Collapsed", "Collapse"),
                                                         new DesignerActionPropertyItem("HeaderCornersRadius",
                                                                                        "Corner's radius [5,10]")
                                                     };
            return items;
        }
    }
}
