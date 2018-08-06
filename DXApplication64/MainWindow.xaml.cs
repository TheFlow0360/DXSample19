using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;

namespace DXApplication64
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class RibbonMerger : DependencyObject
    {
        public static readonly DependencyProperty ChildRibbonsProperty = DependencyProperty.RegisterAttached(
            "ChildRibbons",
            typeof(RibbonCollection),
            typeof(RibbonMerger),
            new PropertyMetadata(ChildRibbonsPropertyChangedCallback)
            );

        private static void ChildRibbonsPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is RibbonControl ribbon))
            {
                throw new InvalidOperationException("This attached property is working exclusively with RibbonControls!");
            }
            if (e.OldValue is RibbonCollection oldCollection)
            {
                foreach (var childRibbon in oldCollection)
                {
                    ribbon.UnMerge(childRibbon);
                }
            }

            if (e.NewValue is RibbonCollection newCollection)
            {
                foreach (var childRibbon in newCollection)
                {
                    ribbon.Merge(childRibbon);
                }
            }
        }

        public static RibbonCollection GetChildRibbons(RibbonControl target)
        {
            return (RibbonCollection)target.GetValue(ChildRibbonsProperty);
        }

        public static void SetChildRibbons(RibbonControl target, RibbonCollection value)
        {
            target.SetValue(ChildRibbonsProperty, value);
        }
    }

    public class RibbonCollection : List<RibbonControl>
    { }
}
