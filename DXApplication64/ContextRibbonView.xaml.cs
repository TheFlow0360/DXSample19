using System;
using System.Windows;

namespace DXApplication64
{
    public partial class ContextRibbonView
    {
        public ContextRibbonView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static readonly DependencyProperty CategoryCaptionProperty = DependencyProperty.Register(
            nameof(CategoryCaption),
            typeof(String),
            typeof(ContextRibbonView));

        public String CategoryCaption { get; set; }
    }
}
