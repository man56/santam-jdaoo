using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace STM.DLayer
{
    public partial class Images : Component
    {
        public Images()
        {
            InitializeComponent();
        }

        public Images(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image StartTest { set; get; }

        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image StopTest { set; get; }

        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image FastUp { set; get; }

        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image SlowUp { set; get; }

        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image FastDown { set; get; }

        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image SlowDown { set; get; }


        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image F0 { set; get; }

        [Browsable(true),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)
        ]
        public Image E0 { set; get; }
    }
}
